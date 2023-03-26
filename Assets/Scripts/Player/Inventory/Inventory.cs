using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
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
		instance = this;
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
