using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDictionary : MonoBehaviour
{
    public List<Weapon> Weapons = new List<Weapon>();

    public string[] getAttackAnimation(weaponType _weaponType)
    {
        foreach (Weapon weapon in Weapons)
        {
            if (weapon.WeaponType == _weaponType)
            {
                return weapon.WeaponAnimation;
            }
        }
        return null;
    }
}

[System.Serializable]
public class Weapon
{
    public weaponType WeaponType;
    public string[] WeaponAnimation;


    public Weapon(weaponType _WeaponType, string[] _WeaponAnimation)
    {
        WeaponType = _WeaponType;
        WeaponAnimation = _WeaponAnimation;
    }
}
