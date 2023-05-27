using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Weapon")]
public class WeaponObject : ItemObject
{
    public weaponType WeaponType;
    public weaponAttackPattern AttackPattern;
    public GameObject WeaponHitbox;

    public int Damage;
    public int AttackSpeed;


}

public enum weaponType
{
    oneHandedAxe,
    oneHandedSword,
    twoHandedAxe,
    twoHandedSword,
    bow
}

public enum weaponAttackPattern
{
    oneHanded,
    twoHanded,
    bow
}

