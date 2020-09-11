using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaPlayerControlerA : MonoBehaviour
{
    [Header("Отключает компоненты движения при надобности.")]
    [SerializeField] private Behaviour[] Components;
    private void Start()
    {
        StartCoroutine(Chect());
    }

    IEnumerator Chect()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (!PlayerLibrary.ActivDialog && !PlayerLibrary.ActivEsc)
            {
                isActiv(true);
            }
            else isActiv(false);
        }
    }

    void isActiv(bool Znach)
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = !Znach;
        for(int i =0; i!=Components.Length; i++)
        {
            Components[i].enabled = Znach;
        }
    }


    public void GiveGun()
    {
        PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>().addItemToInventory(13, 1);
        PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>().updateItemList();
    }

    public void GiveArmor()
    {
        PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>().addItemToInventory(14, 1);
        PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>().addItemToInventory(15, 1);
        PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>().updateItemList();
    }

    public void ActivActor()
    {
        PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.Actor>().enabled = false;
    }

    public void All()
    {
        GiveArmor();
        GiveGun();
        ActivActor();
    }
}
