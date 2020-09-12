using CoverShooter;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class InventaryPlayerJane
{
    public static Inventory InventoryJane = new Inventory();
    public static Inventory InventoryJaneEqv = new Inventory();

    public static void UpdateInventoryJane()
    {
        InventoryJane.ItemsInInventory = PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>().ItemsInInventory;
    }

    public static void UpdatePlayerInventory()
    {
        Inventory PlayerInv = PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>();
        for (int i = 0; i != InventoryJane.ItemsInInventory.Count; i++)
        {
            PlayerInv.addItemToInventory(InventoryJane.ItemsInInventory[i].itemID);
            PlayerInv.updateItemList();
            PlayerInv.stackableSettings();
        }
    }

    public static void UpdateInventraryJane()
    {
       InventoryJaneEqv.ItemsInInventory.Clear();
       for (int i = 0; i!=PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().characterSystem.GetComponent<Inventory>().ItemsInInventory.Count;i++)
        {
            if (PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().characterSystem.GetComponent<Inventory>().ItemsInInventory != null)
                InventoryJaneEqv.ItemsInInventory.Add(PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().characterSystem.GetComponent<Inventory>().ItemsInInventory[i]);
            else InventoryJaneEqv.ItemsInInventory.Add(null);
        }
    }

    public static void UdpatePlayerInventary()
    {

        Inventory PlayerInv = PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().characterSystem.GetComponent<Inventory>();
        for (int i = 0; i!= InventoryJaneEqv.ItemsInInventory.Count; i++)
        {
            if (InventoryJaneEqv.ItemsInInventory[i] == null)
            {
                PlayerInv.ItemsInInventory.Add(null);
            }
            else
            {
                PlayerInv.EquiptItem(InventoryJaneEqv.ItemsInInventory[i]);
                PlayerInv.addItemToInventory(InventoryJaneEqv.ItemsInInventory[i].itemID);
                PlayerInv.updateItemList();
                PlayerInv.stackableSettings();
            }
        }  
    } 


}

