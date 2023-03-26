using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public List<GameObject> inventory;

    public Transform transform;


    private void Awake()
    {
        inventory = new List<GameObject>();
        //_itemDictionary = new Dictionary<Item, InventoryItem>();
        foreach (Transform child in transform)
        {
            inventory.Add(child.gameObject);       
        }
    }


    public Item Get(InventorySlot pItem)
    {
        //if(itemDictionary.TryGetValue(referenceData, out Item value))
        {
            //return value;
        }
        return null;
    }

    public bool ItemInInventory(ItemObject pItem)
    {
        foreach (GameObject slot in inventory)
        {
            if (slot.GetComponent<InventorySlot>().item == pItem)
            {
                return true;
            }
        }
        return false;
    }

    public int GetFreeSlot()
    {
        int count = 0;
        foreach (GameObject slot in inventory)
        {
            if (slot.GetComponent<InventorySlot>().item == null)
            {
                return count;
            }
            count++;
        }
        return 999;
    }



    public void Add(ItemObject pItem)
    {
        int slotNumber = GetFreeSlot();
        Debug.Log(slotNumber);
        if (slotNumber < 999)
        {
            inventory[slotNumber].GetComponent<InventorySlot>().newItem(pItem);
            Debug.Log("added " + pItem.name + " to inventory");
        } else
        {
            Debug.Log("inventory full");
        }



    }

    public void Remove(InventorySlot pSlot)
    {

    }
}
