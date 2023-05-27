using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class PlayerAbilities : MonoBehaviour
{
    public bool playerAlive = true;
    public bool playerStunned = false;  //might not need, just call from state machine

    public float baseHealth;
    public float baseSpeed;
    public float baseArmor;
    public float baseAttackDmg;
    public float baseManaRegen;
    public float baseHealthRegen;
    public float baseStaminaRegen;
    public int baseMaxMana;
    public int baseMaxStamina;

    public float newHealth { get; set; }
    public float newSpeed { get; set; }
    public float newArmor { get; set; }
    public float newAttackDmg { get; set; }
    public float newManaRegen { get; set; }
    public float newHealthRegen { get; set; }

    public int newMaxMana { get; set; }
    public int newMaxStamina { get; set; }


    public float currentHealth { get; set; }
    public float currentStamina { get; set; }


    public Timer timer;


    //player Equipment, spells and slots

    public List<ItemObject> playerEquipment = new List<ItemObject>();

    public List<InventorySlot> playerEquipmentSlots = new List<InventorySlot>();

    public InventorySlot weaponSlot;

    public string weaponAttackAnimation;


    //Hand locations

    public GameObject rightHand;

    private GameObject currentWeaponInRightHand;
    private GameObject weaponHitbox;


    //UI elements
    public Image healthBar;

    public Image staminaBar;

    public Text healthText;

    //Player Attack variables
    //public PlayerAnimation playerAnimation;
    public WeaponDictionary weaponDictionary;
    public int attackSegments;
    public int currentChain = 0;
    public WeaponObject weapon;
    public bool fistAttack = false;
    public bool inAttack = false;
    public bool comboAttack = false;
    public Thread comboTimerThread;


    //Player Spell variables
    public GameObject spellCastPoint;
    public GameObject Spell;


    public void startAttack()
    {
        //if player canAttack
        if (!inAttack) 
        {
            
            //if player is holding weapon
            if (weapon != null)
            {

                //if player is doing a combo attack
                if (comboAttack)
                {
                    comboAttack = false;
                    comboTimerThread.Abort();
                    ++currentChain;
                } 

                

                // if current chain number of attacks from user reaches the end of the weapons attack chain it will reset back to 0
                if (currentChain == weaponDictionary.getAttackAnimation(weapon.WeaponType).Length + 1) currentChain = 0;

                //gets attack animation name from the weapon attack list, then plays the animation
                string[] attackAnimation = weaponDictionary.getAttackAnimation(_weaponType: weapon.WeaponType);
                Debug.Log("playing animation: " + (attackAnimation[currentChain]));
                //playerAnimation.ChangeAnimationState(attackAnimation[currentChain]);
             
                
                return;
            }
            else
            {

                //if player is not holding weapon, they will throw a punch
                if (fistAttack)
                {
                    //playerAnimation.ChangeAnimationState("RightPunch");
                }
                else
                {
                    //playerAnimation.ChangeAnimationState("LeftPunch");
                }
                fistAttack = !fistAttack; //toggles which arm throws the punch
            }
        } 
    }



    public void updatePlayerEquipment()
    {
        playerEquipment = new List<ItemObject>();
        for (int i = 0; i < 4; i++)
        {
            if (playerEquipmentSlots[i].item != null)
            {
                playerEquipment.Add(playerEquipmentSlots[i].item);
            }
        }
        if (weaponSlot.item != null)//if item is in weapon slot
        {
            weapon = (WeaponObject)weaponSlot.item;
        } 
        else
        {
            weapon = null;
        }
    }

    public void resetPlayerStats()
    {
        newHealth = baseHealth;
        newSpeed = baseSpeed;
        newArmor = baseArmor;
        newAttackDmg = baseAttackDmg;
        newManaRegen = baseManaRegen;
        newHealthRegen = baseHealthRegen;
        newMaxMana = baseMaxMana;
        newMaxStamina = baseMaxStamina;
    }

    public void applyEquipmentBuffs()
    {
        resetPlayerStats();
        updatePlayerEquipment();
        Debug.Log("applyEquipBuffs called");
        foreach (ItemObject item in playerEquipment)
        {
            foreach (ItemBuff buff in item.buffs)
            {
                Debug.Log(buff.attribute.ToString() + ", value: " + buff.value);
                switch (buff.attribute.ToString())
                {
                    case "Health":
                        newHealth += buff.value;
                        Debug.Log("currentHealth = " + newHealth);
                        break;
                    case "Armor":
                        newArmor += buff.value;
                        Debug.Log("currentArmor = " + newArmor);
                        break;
                    case "Strength":
                        baseAttackDmg += buff.value;
                        Debug.Log("baseAttackDmg = " + baseAttackDmg);
                        break;
                    case "Speed":
                        
                        float speedAddition = (float) buff.value / 100f;
                        Debug.Log(speedAddition);
                        newSpeed = newSpeed + speedAddition;

                        Debug.Log("currentSpeed = " + newSpeed);
                        break;
                }
            }
            // find buff to add to player from itemID
        }
    }

    public void EquipWeapon()
    {
        Debug.Log("EquipWeapon called");
        //remove item in player hand

        Destroy(currentWeaponInRightHand);

        //get item in weapon slot

        WeaponObject newWeapon = (WeaponObject) weaponSlot.item;

        //currentWeaponInRightHand = Instantiate(newWeapon.WeaponPrefab, rightHand.transform);

        //currentWeaponInRightHand.transform.position = rightHand.transform.position;

        //add weapon buffs to this eventually

    }

    public void UpdateHealth(float change)
    {

        currentHealth += change;

        if (currentHealth > newHealth)
            currentHealth = newHealth;

        healthText.text = currentHealth + "/" + newHealth;
        if (currentHealth <= 0)
        {
            healthText.text = "0/" + newHealth;
            //FindObjectOfType<GameManager>().EndGame();
            Destroy(gameObject);
        }
    }

    public void UpdateStamina(float change)
    {
        currentStamina += change;

        if (currentStamina > newMaxStamina)
            currentStamina = newMaxStamina;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = baseHealth;
        currentStamina = baseMaxStamina;
        applyEquipmentBuffs();
    }

    // Update is called once per frame
    void Update()
    {
        //regen mana and health and lower any abalities that are on CD
        //and update UI's

        if(playerAlive)//if player is not alive do not bother running update method
        {
            Debug.Log("Player is dead");
           return;
        }

        if (currentHealth < newHealth)
        {
            currentHealth += baseHealthRegen * Time.deltaTime;
        } else
        {
            currentHealth += newHealth;
        }

        if (currentStamina < newMaxStamina)
        {
            currentStamina += baseStaminaRegen * Time.deltaTime;
        } else
        {
            currentStamina = baseMaxStamina;
        }

        //updates visual UI's for health and stamina
        healthBar.fillAmount = currentHealth / newHealth;
        staminaBar.fillAmount = currentStamina / newMaxStamina;


        updateFixedTime();
    }


    public void enterAttack()
    {
        inAttack = true;

        weaponHitbox = Instantiate(weapon.WeaponHitbox, rightHand.transform);
    }

    public void enableCombo()
    {
        inAttack = false;
        comboAttack = true;
        //maybe do this on a thread 
        comboTimerThread = new Thread(startComboTimer);
        comboTimerThread.Start();
        Destroy(weaponHitbox);
    }

    public void startComboTimer()
    {
        Debug.Log("Timer started");
        float timeStart = FixedTime;
        while (true)
        {
            if ((timeStart + 2f) < FixedTime)
            {
                Debug.Log("Timer done");
                comboAttack = false;
                currentChain = 0;
                return;
            }
        
        }
    }

    public float FixedTime;

    public void updateFixedTime()
    {
        FixedTime = Time.fixedTime;
    }

    // 1 will reset weapon combo chain
    public void exitAttack(int disableCombo)
    {
        inAttack = false;
        Destroy(weaponHitbox);
        if (disableCombo == 1) currentChain = 0;
    }

    //new idea
    //after a combo-able animaiton has been played
    //enable a combo follow up for 0.5 seconds, to play the next animation


    public void castSpell()
    {
        GameObject projectile = Instantiate(Spell, spellCastPoint.transform.position, spellCastPoint.transform.rotation);
    }

}
