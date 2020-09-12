using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarySave : MonoBehaviour
{
    private enum PlayerName
    {
        Jane = 0,
        Carl = 1
    }

    [SerializeField] private PlayerName Player = PlayerName.Carl;

    private void Start()
    {
        PlayerLibrary.PlayerGameObject = gameObject;
        InventaryPlayerJane.UpdatePlayerInventory();
        InventaryPlayerJane.UdpatePlayerInventary();
        StartCoroutine(ReInventory());
    }

    IEnumerator ReInventory()
    {
        while (true)
        {
            
            InventaryPlayerJane.UpdateInventoryJane();
            InventaryPlayerJane.UpdateInventraryJane();
            yield return new WaitForSeconds(2f);
        }
    }

   
}
