using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<ItemObject> Inventory; 
    public List<GameObject> inventorySlots;
    public Transform InventoryPanel;
    public Transform itemsParent;
    Inventory inventory;
    InventorySlot[] slots;



    // Start is called before the first frame update
    void Start()
    {
        int count = 0;
        //Load save data into Inventory
        foreach (ItemObject item in Inventory)
        {
            inventorySlots[count].GetComponent<InventorySlot>().newItem(item);
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public GameManager gameManager;


    #region Tabs
    public void openInventory()
    {
        Debug.Log("Inventory pressed");
        //gameManager.changeMenuState("openBook inventory");
    }

    public void openSettings()
    {
        Debug.Log("settings pressed");
        //gameManager.changeMenuState("openBook settings");
    }
    #endregion



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

    // Our current list of items in the inventory
    public List<Item> items = new List<Item>();



    public void OnEnable()
    {

    }



    // Add a new item if enough room
    public void Add(Item item)
    {

        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return;
        }

        items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

    }

    // Remove an item
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void Select(int slot)
    {
        if (items[slot].Equals(null))
        {
            Debug.Log("item slot: " + slot + " empty");
        }

    }
}
