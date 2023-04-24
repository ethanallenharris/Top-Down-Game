using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBars : MonoBehaviour
{

    public Entity playerStats;
    public Image healthBar;
    public Image manaBar;
    public Image staminaBar;


    void Update()
    {
        // Health bar
        float healthFill = playerStats.CurrentHealthLevel / playerStats.CurrentMaxHealth;
        healthBar.fillAmount = healthFill;

        //Mana bar
        float manaFill = playerStats.CurrentManaLevel / playerStats.CurrentMaxMana;
        manaBar.fillAmount = manaFill;

        //Stamina bar
        float staminaFill = playerStats.CurrentStaminaLevel / playerStats.CurrentMaxStamina;
        staminaBar.fillAmount = staminaFill;
    }
}
