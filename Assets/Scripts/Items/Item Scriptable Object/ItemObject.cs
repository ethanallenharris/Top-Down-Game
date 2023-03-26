using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemObject : ScriptableObject
{
    public string ID;


    public ItemBuff[] buffs;

    public string description;

    public Sprite icon = null;
    public bool isDefaultItem = false;
    public int stackSize;
    public itemType itemType;

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }

}
    

    //public string itemType;

[System.Serializable]
public class Item
{
    public string uniqueID;
    public string ID;
    new public string name = "New Item";
    public ItemBuff[] buffs { get; private set; }
    public itemType itemType;

    public Item(ItemObject item)
    {
        name = item.name;
        ID = item.ID;
        itemType = item.itemType;
        buffs = new ItemBuff[item.buffs.Length];
        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.buffs[i].attribute, item.buffs[i].value);
        }
    }

}




public enum itemType
{
    Material,
    Ammunition,
    Helmet,
    ChestPiece,
    Leggings,
    Boots,
    Weapon
}

public enum Attributes
{
    Health,
    Armor,
    Strength,
    Speed
}

[System.Serializable]
public class ItemBuff
{
    public Attributes attribute;
    public float value;

    public ItemBuff(Attributes _attribute, float _value)
    {
        attribute = _attribute;
        value = _value;
    }
}



