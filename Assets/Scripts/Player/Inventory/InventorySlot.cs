using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    private PlayerStateMachine playerStateMachine;

    public Text itemCount;
    public Image icon;
    public Button select;
    public SlotType slotType;
    public bool isEquipment;
    public ItemObject item { get; private set; }
    public int stackSize { get; private set; }


    void Start()
    {
        icon.enabled = false;
        playerStateMachine = FindObjectOfType<PlayerStateMachine>();
    }

    public enum SlotType
    {
        Inventory,
        Helmet,
        ChestPiece,
        Leggings,
        Boots,
        Weapon
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack()
    {
        stackSize--;
    }

    public void newItem(ItemObject newItem)
    {       
        item = newItem;
        AddToStack();
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;

        RectTransform rect = transform as RectTransform;
        rect.SetAsFirstSibling();

        if (isEquipment)
        {
            //playerStateMachine.applyEquipmentBuffs();
            //playerStateMachine.EquipWeapon();
        }

  
    }

    public void SelectItem()
    {
        //make the item go into the selected slot
    }

    //String returned tells if itemslot is occupied, or if slot is invalid (i.e. pants into headpiece slot)
    public string InsertItem(ItemObject newItem)
    {
        if (newItem.itemType.ToString() == slotType.ToString() | slotType.ToString() == "Inventory")
        {
            //do an IF for item conditions (i.e. is player has 100+ strength)
            if (item != null)
            {
                //put new item in current items place
                //current item will now be held by the player
            }



        }
        return "invalid";
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform slotPanel = transform as RectTransform;

        if (RectTransformUtility.RectangleContainsScreenPoint(slotPanel,
            Input.mousePosition))
        {
           // Debug.Log("Item moved to slot");
           // Debug.Log(slotPanel);
        }

        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);


        InventorySlot targetSlot = null;
        foreach (var result in results)
        {
            targetSlot = result.gameObject.GetComponent<InventorySlot>();
            if (targetSlot != null && targetSlot != this.gameObject.GetComponent<InventorySlot>())
            {
                break;
            }
        }
        
        if (targetSlot != null)
        {
            if (this.item.itemType.ToString() == targetSlot.slotType.ToString() | targetSlot.slotType.ToString() == "Inventory")
            {
                if (targetSlot.item != null)
                {
                    ItemObject itemSwapStorage = item;
                    this.newItem(targetSlot.item);
                    targetSlot.newItem(itemSwapStorage);

                }
                else
                {
                    targetSlot.newItem(item);
                    this.ClearSlot();
                }
                if (targetSlot.isEquipment)
                {
                    Debug.Log("Update stats");
                    //playerStateMachine.applyEquipmentBuffs();
                    //playerStateMachine.EquipWeapon();
                    //update stats, passives and weapon
                }
            }
        }
    }


}
