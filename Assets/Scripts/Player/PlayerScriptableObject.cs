using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBase
{

    //Objects
    public camera mainCamera;
    public GameObject player;

    //Stats
    public float maxHealth;
    public float currentHealth;
    public float maxStamina;
    public float currentStamina;
    public int strength;
    public int spellPower;
    public int armour;
    
}
