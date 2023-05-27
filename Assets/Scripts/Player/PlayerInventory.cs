using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerInventory : MonoBehaviour
{
    public List<ItemObject> Inventory; 
    public List<GameObject> inventorySlots;
    public Transform InventoryPanel;
    Inventory inventory;
    InventorySlot[] slots;

    public List<ItemObject> RandomItemList;



    // Start is called before the first frame update
    void Start()
    {
        int count = 0;
        //Load save data into Inventory
        foreach (ItemObject item in Inventory)
        {
            //inventorySlots[count].GetComponent<InventorySlot>().newItem(item);
            count++;
        }
    }

    public bool ItemInInventory(ItemObject pItem)
    {
        foreach (GameObject slot in inventorySlots)
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
        foreach (GameObject slot in inventorySlots)
        {
            if (slot.GetComponent<InventorySlot>().item == null)
            {
                return count;
            }
            count++;
        }
        return 999;
    }

    public void TESTBUTTON(string message)
    {
        Debug.Log(message);
    }


    public void Add(ItemObject pItem)
    {
        Debug.Log("Add item2");
        int slotNumber = GetFreeSlot();
        Debug.Log(slotNumber);
        if (slotNumber < 999)
        {
            inventorySlots[slotNumber].GetComponent<InventorySlot>().newItem(pItem);
            Debug.Log("added " + pItem.name + " to inventory");
        }
        else
        {
            Debug.Log("inventory full");
        }
    }



    public void AddRandom()
    {
        int slotNumber = GetFreeSlot();
        if (slotNumber < 999)
        {
            int randomNumber = Random.Range(0, RandomItemList.Count);
            inventorySlots[slotNumber].GetComponent<InventorySlot>().newItem(RandomItemList[randomNumber]);
            Debug.Log("added " + RandomItemList[randomNumber].name + " to inventory");
        }
        else
        {
            Debug.Log("inventory full");
        }

    }



    public void Remove(InventorySlot pSlot)
    {

    }

    void UpdateUI()
    {
        Debug.Log("");

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                //  slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }


    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        //instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 10;  // Amount of item spaces
}
