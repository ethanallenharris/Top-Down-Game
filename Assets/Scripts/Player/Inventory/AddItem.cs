using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{

    public List<ItemObject> items = new List<ItemObject>();

    private int counter;

    private PlayerInventory inventorySystem;

    public void OnHandlePickupItem()
    {
        Debug.Log("Add item");
        counter++;
        inventorySystem = FindObjectOfType<PlayerInventory>();
       
        int randomNumber = Random.Range(0, items.Count);
        inventorySystem.Add(items[randomNumber]);
    }

    public void AddRandomItem()
    {

    }

}
