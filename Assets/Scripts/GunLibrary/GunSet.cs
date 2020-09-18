using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSet : MonoBehaviour
{
    public int IdGun = 0;
    public int IdRifle = 0;
    public int IdArmor = 0;
    public int IdHead = 0;
    public GameObject[] Obeject;
    public GameObject[] Rifle;
    public GameObject[] Armor;
    public GameObject[] Head;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HideAll()
    {
        PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.CharacterInventory>().Weapons[0].RightItem = null;
        PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.CharacterInventory>().Weapons[0].RightHolster = null;
        for (int i =0; i != Obeject.Length; i++)
        {
            if(Obeject[i] != null)
            Obeject[i].SetActive(false);
        }
    }
    public void HideArmor()
    {
        Armor[0].SetActive(false);
        for (int i = 0; i != Armor.Length; i++)
        {
            Armor[i].SetActive(false);
        }
    }
    public void HideHrad()
    {
        Head[0].SetActive(false);
        for (int i = 0; i != Head.Length; i++)
        {
            Head[i].SetActive(false);
        }
    }


    public void HideAllRifle()
    {
        PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.CharacterInventory>().Weapons[1].RightItem = null;
        PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.CharacterInventory>().Weapons[1].RightHolster = null;
        for (int i = 0; i != Rifle.Length; i++)
        {
            if(Rifle[i] != null)
            Rifle[i].SetActive(false);
        }
    }

    public void ShopArmor()
    {
        Armor[IdArmor].SetActive(true);
    }
    public void ShopHead()
    {
        Head[IdHead].SetActive(true);
    }
    public void ShowRifleLeft()
    {
        PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.CharacterInventory>().Weapons[1].RightItem = Rifle[IdRifle];
        PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.CharacterInventory>().Weapons[1].RightItem.GetComponent<HideShowScripts>().Show();
    }
    public void ShowRifleSpine()
    {
        Rifle[IdRifle].SetActive(true);
        PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.CharacterInventory>().Weapons[1].RightHolster = Rifle[IdRifle];

    }


    public void ShowPistolLeft()
    {
        PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.CharacterInventory>().Weapons[0].RightItem = Obeject[IdGun];
        PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.CharacterInventory>().Weapons[0].RightItem.GetComponent<HideShowScripts>().Show();
    }
    public void ShowPistolLegs()
    {
        Obeject[IdGun].SetActive(true);
       
        PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.CharacterInventory>().Weapons[0].RightHolster = Obeject[IdGun];

    }
}
