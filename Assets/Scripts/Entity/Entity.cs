using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //Base stats for player / entity
    public float baseMaxHealth = 100f;
    public float baseHealthRegen = 1f;
    public float baseAttack = 10f;
    public float baseDefense = 0f;
    public float baseMaxMana = 100f;
    public float baseManaAffinity = 1;
    public float baseManaRegen = 1f;
    public float baseMaxStamina = 100f;
    public float baseStaminaRegen = 1f;
    public float baseInvincibilityTime = 0.3f;
 


    //other entity stats
    public bool alive;
    public int level;



    //These values will be the players current stats after their buffs and debuffs have been calculated
    private float _currentMaxHealth;
    private float _currentHealthLevel;
    private float _currentHealthRegen;
    private float _currentAttackPower;
    private float _currentDefense;
    private float _currentMaxMana;
    private float _currentManaLevel;
    private float _currentManaRegen;
    private float _currentManaAffinity; //Player base magic power level
    private float _currentMagicPower; // Magic power determines weapon damage + size -- Magic power = Item power + magic affinity
    private float _currentMaxStamina;
    private float _currentStaminaLevel;
    private float _currentStaminaRegen;
    private float _currentInvincibilityTime;

    private float StaminaDrain = 0;

    //getters and setters
    #region getters and setters
    public float CurrentMaxHealth
    {
        get { return _currentMaxHealth; }
        set { _currentMaxHealth = value; }
    }

    public float CurrentHealthLevel
    {
        get { return _currentHealthLevel; }
        set { _currentHealthLevel = value; }
    }

    public float CurrentHealthRegen
    {
        get { return _currentHealthRegen; }
        set { _currentHealthRegen = value; }
    }

    public float CurrentAttackPower
    {
        get { return _currentAttackPower; }
        set { _currentAttackPower = value; }
    }

    public float CurrentDefense
    {
        get { return _currentDefense; }
        set { _currentDefense = value; }
    }

    public float CurrentMaxMana
    {
        get { return _currentMaxMana; }
        set { _currentMaxMana = value; }
    }

    public float CurrentManaLevel
    {
        get { return _currentManaLevel; }
        set { _currentManaLevel = value; }
    }

    public float CurrentManaRegen
    {
        get { return _currentManaRegen; }
        set { _currentManaRegen = value; }
    }

    public float CurrentManaAffinity
    {
        get { return _currentManaAffinity; }
        set { _currentManaAffinity = value; }
    }

    public float CurrentMagicPower
    {
        get { return _currentMagicPower; }
        set { _currentMagicPower = value; }
    }

    public float CurrentMaxStamina
    {
        get { return _currentMaxStamina; }
        set { _currentMaxStamina = value; }
    }

    public float CurrentStaminaLevel
    {
        get { return _currentStaminaLevel; }
        set { _currentStaminaLevel = value; }
    }

    public float CurrentStaminaRegen
    {
        get { return _currentStaminaRegen; }
        set { _currentStaminaRegen = value; }
    }

    public float CurrentInvincibilityTime
    {
        get { return _currentInvincibilityTime; }
        set { _currentInvincibilityTime = value; }
    }
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        Reset();
        Update();
    }

    private void Update()
    {
        #region regeneration
        // Regen health
        if (_currentHealthLevel + _currentHealthRegen >= _currentMaxHealth)
        {
            _currentHealthLevel = _currentMaxHealth;
        } else
        {
            _currentHealthLevel += _currentHealthRegen;
        }

        //Regen Mana
        if ((_currentStaminaLevel + ((_currentStaminaRegen - StaminaDrain) * Time.deltaTime)) >= _currentMaxStamina)
        {
            _currentStaminaLevel = _currentMaxStamina;
        }
        else if ((_currentStaminaLevel + ((_currentStaminaRegen - StaminaDrain) * Time.deltaTime)) <= 0)
        {
            _currentStaminaLevel = 0;
        }
        else
        {
            _currentStaminaLevel += (_currentStaminaRegen - StaminaDrain) * Time.deltaTime;
        }
        

        //Regen Stamina
        if (_currentManaLevel + _currentManaRegen >= _currentMaxMana)
        {
            _currentManaLevel = _currentMaxMana;
        }
        else
        {
            _currentManaLevel += _currentManaRegen;
        }
        #endregion


    }


    public void Reset()
    {
        _currentMaxHealth = baseMaxHealth;
        _currentHealthLevel = baseMaxHealth; // Assuming the current level starts from zero
        _currentHealthRegen = baseHealthRegen;
        _currentAttackPower = baseAttack;
        _currentDefense = baseDefense;
        _currentMaxMana = baseMaxMana;
        _currentManaLevel = baseMaxMana; // Assuming the current mana level starts from zero
        _currentManaRegen = baseManaRegen;
        _currentManaAffinity = baseManaAffinity;
        _currentMagicPower = baseManaAffinity; // Assuming base magic affinity is the same as base magic power
        _currentMaxStamina = baseMaxStamina;
        _currentStaminaLevel = baseMaxStamina; // Assuming the current stamina level starts from zero
        _currentStaminaRegen = baseStaminaRegen;
        _currentInvincibilityTime = baseInvincibilityTime;
        alive = true;
    }

    public void UpdateStats()
    {
        // Update stat or something idk
    }

    public void TakeDamage(float value)
    {
        if (_currentHealthLevel - value <= 0)
        {
            _currentHealthLevel = 0;
            //Stop alowing player to move and take tamage
            alive = false;
            Debug.Log("Player is dead");
        }
        else
        {
            _currentHealthLevel -= value;
        }
    }

    public void Heal(float value)
    {
        if (_currentHealthLevel + value >= baseMaxHealth)
        {
            _currentHealthLevel = baseMaxHealth;
        }
        else
        {
            _currentHealthLevel += value;
        }
    }


    public bool StaminaLose(float value)
    {
        if (_currentStaminaLevel - value <= 0)
        {
            return false; //Player cant perform stamina taking action
        }
        else
        {
            _currentStaminaLevel -= value;
            return true;
        }
    }

    public void SetStaminaDrain(float value)
    {
        StaminaDrain = value;
    }




}
