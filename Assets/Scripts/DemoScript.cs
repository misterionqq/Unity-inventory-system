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
        Debug.Log("Вызов Добавления Предмета");
        inventoryManager.AddItem(itemsToPickup[id]);
    }
}
