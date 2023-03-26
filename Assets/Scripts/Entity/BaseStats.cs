using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    //Base stats for player / entity
    public float baseHealth = 100f;
    public float baseHealthRegen = 1f;
    public float baseAttack = 10f;
    public float baseDefense = 0f;
    public float baseMana = 100f;
    public float baseManaRegen = 1f;
    public float baseManaPower = 10f;
    public float baseStamina = 100f;
    public float baseStaminaRegen = 1f;
    public float baseInvincibilityTime = 0.3f;
    

    //other entity stats
    public bool alive;
    public int level;



    //These values will be the players current stats after their buffs and debuffs have been calculated
    private float _currentHealth;
    private float _currentHealthRegen;
    private float _currentAttack;
    private float _currentDefense;
    private float _currentMana;
    private float _currentManaRegen;
    private float _currentManaPower;
    private float _currentStamina;
    private float _currentStaminaRegen;
    private float _currentInvincibilityTime;

    //getters and setters
    #region getters and setters
    public float CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    public float CurrentHealthRegen
    {
        get { return _currentHealthRegen; }
        set { _currentHealthRegen = value; }
    }

    public float CurrentAttack
    {
        get { return _currentAttack; }
        set { _currentAttack = value; }
    }

    public float CurrentDefense
    {
        get { return _currentDefense; }
        set { _currentDefense = value; }
    }

    public float CurrentMana
    {
        get { return _currentMana; }
        set { _currentMana = value; }
    }

    public float CurrentManaRegen
    {
        get { return _currentManaRegen; }
        set { _currentManaRegen = value; }
    }

    public float CurrentManaPower
    {
        get { return _currentManaPower; }
        set { _currentManaPower = value; }
    }

    public float CurrentStamina
    {
        get { return _currentStamina; }
        set { _currentStamina = value; }
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
        alive = true;

        // Set current stats to base of character 
        _currentHealth = baseHealth;
        _currentHealthRegen = baseHealthRegen;
        _currentAttack = baseAttack;
        _currentDefense = baseDefense;
        _currentMana = baseMana;
        _currentManaRegen = baseManaRegen;
        _currentManaPower = baseManaPower;
        _currentStamina = baseStamina;
        _currentStaminaRegen = baseStaminaRegen;
        _currentInvincibilityTime = baseInvincibilityTime;
    }


    public void Reset()
    {
        _currentHealth = baseHealth;
        _currentHealthRegen = baseHealthRegen;
        _currentAttack = baseAttack;
        _currentDefense = baseDefense;
        _currentMana = baseMana;
        _currentManaRegen = baseManaRegen;
        _currentManaPower = baseManaPower;
        _currentStamina = baseStamina;
        _currentStaminaRegen = baseStaminaRegen;
        _currentInvincibilityTime = baseInvincibilityTime;
        alive = true;
    }

    // Function to update stat based on changes from armor, trinkets, buffs/debuffs or incoming damage/healing
    public void UpdateStat(string statName, float floatValue)
    {
        switch (statName)
        {
            case "Health":
                // do something for Health variable
                break;
            case "HealthRegen":
                // do something for HealthRegen variable
                break;
            case "Attack":
                // do something for Attack variable
                break;
            case "Defense":
                // do something for Defense variable
                break;
            case "Mana":
                // do something for Mana variable
                break;
            case "ManaRegen":
                // do something for ManaRegen variable
                break;
            case "Stamina":
                // do something for Stamina variable
                break;
            case "StaminaRegen":
                // do something for StaminaRegen variable
                break;
            default:
                // default case is when variable does not match any case option
                //Outputs error message with list of available options
                Debug.Log("BaseStats UpdateStats statName :'" + statName + "' option not recognised \n" +
                    "list of stat options: Health, HealthRegen, Attack, Defense, Mana, ManaRegen, StaminaRegen");
                break;
        }
    }


}
