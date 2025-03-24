using System.Diagnostics;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;

    public void PickupItem(int id)
    {
        Debug.Log("Calling PickupItem");
        bool result = inventoryManager.AddItem(itemsToPickup[id]);

        if (result)
        {
            Debug.Log("Item added");
        }
        else
        {
            Debug.Log("Item not added");
        }
    }

    public void GetSelectedItem()
    {
        Debug.Log("Calling GetSelectedItem");
        Item recievedItem = inventoryManager.GetSelectedItem(false);
        if (recievedItem != null)
        {
            Debug.Log("Recieved item: " + recievedItem);
        }
        else
        {
            Debug.Log("No item recieved");
        }
    }
    
    public void UseSelectedItem()
    {
        Debug.Log("Calling UseSelectedItem");
        Item recievedItem = inventoryManager.GetSelectedItem(true);
        if (recievedItem != null)
        {
            Debug.Log("Used item: " + recievedItem);
        }
        else
        {
            Debug.Log("No item used");
        }
    }
}