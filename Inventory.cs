using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public static Inventory instance;
    public GameObject GoldText;
    private int gold = 0;


    public int space = 10;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory");
            return;
        }

        instance = this;
        
    }

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Max on room");
                return false;
            }
            items.Add(item);
        }
        return true;

    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }


    public void Upgrade(int upgradeID)
    {

        Debug.Log(upgradeID);

        switch (upgradeID)
        {
            case 0: // increase shoot speed
                
                break;
            case 1: // increase bullet damage
                
                break;
            case 2: // reduce dash cooldown
                
                break;
            case 3: // chance to shoot freeze shot

                break;
            case 4: // chance to shoot fireball

                break;
            case 5: // increase bullets fired

                break;
            case 6: // dash will drop a mine into the ground

                break;
            case 7: // dash fire a knife at the nearest enemy

                break;

        }

    }
}
