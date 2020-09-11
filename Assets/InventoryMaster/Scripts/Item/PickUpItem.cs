﻿using UnityEngine;
using System.Collections;


public class PickUpItem : MonoBehaviour
{
    public Item item;
    private Inventory _inventory;
    private GameObject _player;
 
    void Start()
    {
        transform.position = new Vector3(PlayerLibrary.PlayerGameObject.transform.position.x, PlayerLibrary.PlayerGameObject.transform.position.y+2f, PlayerLibrary.PlayerGameObject.transform.position.z);
       gameObject.AddComponent<Rigidbody>();
       gameObject.AddComponent<BoxCollider>().size = new Vector3(1, 1, 1);
    }
    public void E(GameObject hit)
    {
        _player = PlayerLibrary.PlayerGameObject;
        if (_player != null)
        {
            Debug.Log("++");
            _inventory = _player.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>();
            Debug.Log(_inventory.ItemsInInventory.Count);
        } Debug.LogError("Player=null");
        if (_inventory == null) Debug.Log("Нету инвентаря");
      
        else if (_inventory.ItemsInInventory.Count < (_inventory.width * _inventory.height))
        {
            _inventory.addItemToInventory(item.itemID, item.itemValue);
            _inventory.updateItemList();
            _inventory.stackableSettings();
            Destroy(this.gameObject);
        }
    }
    IEnumerator DestroRigitBody()
    {
        yield return new WaitForSeconds(4f);
        Destroy(GetComponent<Rigidbody>());
    }
}