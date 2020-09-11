﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PlayerInventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject characterSystem;
    public GameObject craftSystem;
    private Inventory craftSystemInventory;
    private CraftSystem cS;
    public Inventory mainInventory;
    public Inventory characterSystemInventory;
    public Tooltip toolTip;

    [SerializeField] private Transform RHand;
    [SerializeField] private Transform BackPack;
    [SerializeField] private Transform Spine;
    [SerializeField] private Transform Tors;
    [SerializeField] private Transform Armor;
    [SerializeField] private Transform Head;

    private InputManager inputManagerDatabase;

    public GameObject HPMANACanvas;

    int normalSize = 3;

    public void OnEnable()
    {
        Inventory.ItemEquip += OnBackpack;
        Inventory.UnEquipItem += UnEquipBackpack;

        Inventory.ItemEquip += OnGearItem;
        Inventory.ItemConsumed += OnConsumeItem;
        Inventory.UnEquipItem += OnUnEquipItem;

        Inventory.ItemEquip += EquipWeapon;
        Inventory.UnEquipItem += UnEquipWeapon;
    }

    public void OnDisable()
    {
        Inventory.ItemEquip -= OnBackpack;
        Inventory.UnEquipItem -= UnEquipBackpack;

        Inventory.ItemEquip -= OnGearItem;
        Inventory.ItemConsumed -= OnConsumeItem;
        Inventory.UnEquipItem -= OnUnEquipItem;

        Inventory.UnEquipItem -= UnEquipWeapon;
        Inventory.ItemEquip -= EquipWeapon;
    }

    void EquipWeapon(Item item)
    {
        if (item.itemType == ItemType.Weapon)
        {
            //add the weapon if you unequip the weapon
        }
    }

    void UnEquipWeapon(Item item)
    {
        if (item.itemType == ItemType.Weapon)
        {
            //delete the weapon if you unequip the weapon
        }
    }

    void OnBackpack(Item item)
    {
        if (item.itemType == ItemType.Backpack)
        {
            for (int i = 0; i < item.itemAttributes.Count; i++)
            {
                if (mainInventory == null)
                    mainInventory = inventory.GetComponent<Inventory>();
                mainInventory.sortItems();
                if (item.itemAttributes[i].attributeName == "Slots")
                    changeInventorySize(item.itemAttributes[i].attributeValue);
            }
        }
    }

    void UnEquipBackpack(Item item)
    {
        if (item.itemType == ItemType.Backpack)
            changeInventorySize(normalSize);
    }

    void changeInventorySize(int size)
    {
        dropTheRestItems(size);

        if (mainInventory == null)
            mainInventory = inventory.GetComponent<Inventory>();
        if (size == 3)
        {
            mainInventory.width = 3;
            mainInventory.height = 1;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        if (size == 6)
        {
            mainInventory.width = 3;
            mainInventory.height = 2;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        else if (size == 12)
        {
            mainInventory.width = 4;
            mainInventory.height = 3;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        else if (size == 16)
        {
            mainInventory.width = 4;
            mainInventory.height = 4;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        else if (size == 24)
        {
            mainInventory.width = 6;
            mainInventory.height = 4;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
    }

    void dropTheRestItems(int size)
    {
        if (size < mainInventory.ItemsInInventory.Count)
        {
            for (int i = size; i < mainInventory.ItemsInInventory.Count; i++)
            {
                GameObject dropItem = (GameObject)Instantiate(mainInventory.ItemsInInventory[i].itemModel);
                dropItem.AddComponent<PickUpItem>();
                dropItem.GetComponent<PickUpItem>().item = mainInventory.ItemsInInventory[i];
                dropItem.transform.localPosition = GameObject.FindGameObjectWithTag("Player").transform.localPosition;
            }
        }
    }

    void Start()
    {
        PlayerLibrary.PlayerGameObject = gameObject;
        //if (HPMANACanvas != null)
        //{
        //    hpText = HPMANACanvas.transform.GetChild(1).GetChild(0).GetComponent<Text>();

        //    manaText = HPMANACanvas.transform.GetChild(2).GetChild(0).GetComponent<Text>();

        //    hpImage = HPMANACanvas.transform.GetChild(1).GetComponent<Image>();
        //    manaImage = HPMANACanvas.transform.GetChild(1).GetComponent<Image>();

        //    UpdateHPBar();
        //    UpdateManaBar();
        //}

        if (inputManagerDatabase == null)
            inputManagerDatabase = (InputManager)Resources.Load("InputManager");

        if (craftSystem != null)
            cS = craftSystem.GetComponent<CraftSystem>();

        if (GameObject.FindGameObjectWithTag("Tooltip") != null)
            toolTip = GameObject.FindGameObjectWithTag("Tooltip").GetComponent<Tooltip>();
        if (inventory != null)
            mainInventory = inventory.GetComponent<Inventory>();
        if (characterSystem != null)
            characterSystemInventory = characterSystem.GetComponent<Inventory>();
        if (craftSystem != null)
            craftSystemInventory = craftSystem.GetComponent<Inventory>();
    }

    //void UpdateHPBar()
    //{
    //    hpText.text = (currentHealth + "/" + maxHealth);
    //    float fillAmount = currentHealth / maxHealth;
    //    hpImage.fillAmount = fillAmount;
    //}

    //void UpdateManaBar()
    //{
    //    manaText.text = (currentMana + "/" + maxMana);
    //    float fillAmount = currentMana / maxMana;
    //    manaImage.fillAmount = fillAmount;
    //}

    IEnumerator UseItem(int i,string Atr, int Value)
    {
        PlayerLibrary.UseItem = true;

        GameObject.FindGameObjectWithTag("CunvasPlayer").GetComponent<PlayerCunvas>().ActivatedItemSlider.GetComponent<Slider>().value = 0;
        GameObject.FindGameObjectWithTag("CunvasPlayer").GetComponent<PlayerCunvas>().ActivatedItemSlider.SetActive(true);
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameObject.FindGameObjectWithTag("CunvasPlayer").GetComponent<PlayerCunvas>().ActivatedItemSlider.GetComponent<Slider>().value += 0.25f;
            if (GameObject.FindGameObjectWithTag("CunvasPlayer").GetComponent<PlayerCunvas>().ActivatedItemSlider.GetComponent<Slider>().value >= GameObject.FindGameObjectWithTag("CunvasPlayer").GetComponent<PlayerCunvas>().ActivatedItemSlider.GetComponent<Slider>().maxValue)
            {
                GameObject.FindGameObjectWithTag("CunvasPlayer").GetComponent<PlayerCunvas>().ActivatedItemSlider.SetActive(false);
                PlayerLibrary.UseItem = false;

                if (Atr == "Heal")
                {
                    PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.CharacterHealth>().Health += Value;
                    if (PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.CharacterHealth>().Health > PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.CharacterHealth>().MaxHealth) PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.CharacterHealth>().Health = PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.CharacterHealth>().MaxHealth;
                }
                break;


            }
        }
    }

    public void OnConsumeItem(Item item)
    
    {
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            if (item.itemAttributes[i].attributeName == "Pistol")
            {
                RHand.GetComponent<GunSet>().IdGun += item.itemAttributes[i].attributeValue;
                Spine.GetComponent<GunSet>().IdGun += item.itemAttributes[i].attributeValue;
                StartCoroutine(EqvipGun());
            }

            if (item.itemAttributes[i].attributeName == "Heal")
            {
                StartCoroutine(UseItem(0, "Heal", item.itemAttributes[i].attributeValue));
            }

            if (item.itemAttributes[i].attributeName == "Rifle")
            {
                RHand.GetComponent<GunSet>().IdRifle += item.itemAttributes[i].attributeValue;
                Tors.GetComponent<GunSet>().IdRifle += item.itemAttributes[i].attributeValue;
                StartCoroutine(EqviRifle());
            }
            if(item.itemAttributes[i].attributeName == "Body")
            {
                float q = item.itemAttributes[i].attributeValue;
                float Val = ((q) / 100);
                StartCoroutine(EqvipArmor());
                PlayerLibrary.CurrectScaleBody(false,Val);
            }
            if (item.itemAttributes[i].attributeName == "Head")
            {
                float q = item.itemAttributes[i].attributeValue;
                float Val = ((q) / 100);
                StartCoroutine(Eqviphead());
                PlayerLibrary.CurrectScaleHead(false, Val);
            }
            if(item.itemAttributes[i].attributeName == "None")
            {
                PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>().addItemToInventory(item.itemID);
                PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>().updateItemList();
                PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>().stackableSettings();

            }


        }
        //if (HPMANACanvas != null)
        //{
        //    UpdateManaBar();
        //    UpdateHPBar();
        //}
    }
    public IEnumerator EqvipGun()
    {
        yield return new WaitForEndOfFrame();
        RHand.GetComponent<GunSet>().HideAll();
        Spine.GetComponent<GunSet>().HideAll();
        RHand.GetComponent<GunSet>().ShowPistolLeft();
        Spine.GetComponent<GunSet>().ShowPistolLegs();

    }

    public IEnumerator EqvipArmor()
    {
        yield return new WaitForEndOfFrame();
        Armor.GetComponent<GunSet>().HideArmor();
        Armor.GetComponent<GunSet>().ShopArmor();
            

    }

    public IEnumerator Eqviphead()
    {
        yield return new WaitForEndOfFrame();
        Head.GetComponent<GunSet>().HideHrad();
        Head.GetComponent<GunSet>().ShopHead();


    }

    public IEnumerator EqviRifle()
    {
        yield return new WaitForEndOfFrame();
        RHand.GetComponent<GunSet>().HideAllRifle();
        Tors.GetComponent<GunSet>().HideAllRifle();
        RHand.GetComponent<GunSet>().ShowRifleLeft();
        Tors.GetComponent<GunSet>().ShowRifleSpine();

    }

    public void OnGearItem(Item item)
    {
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            if (item.itemAttributes[i].attributeName == "Pistol")
            {
               
                RHand.GetComponent<GunSet>().IdGun += item.itemAttributes[i].attributeValue;
                Spine.GetComponent<GunSet>().IdGun += item.itemAttributes[i].attributeValue;
                StartCoroutine(EqvipGun());
            }

            if (item.itemAttributes[i].attributeName == "Rifle")
            {
                RHand.GetComponent<GunSet>().IdRifle += item.itemAttributes[i].attributeValue;
                Tors.GetComponent<GunSet>().IdRifle += item.itemAttributes[i].attributeValue;
                StartCoroutine(EqviRifle());
            }

            if(item.itemAttributes[i].attributeName == "Body")
            {
                float q = item.itemAttributes[i].attributeValue;
                float Val = ((q) / 100);
                StartCoroutine(EqvipArmor());
                PlayerLibrary.CurrectScaleBody(false, Val);
            }
            if (item.itemAttributes[i].attributeName == "Head")
            {
                float q = item.itemAttributes[i].attributeValue;
                float Val = ((q) / 100);
                StartCoroutine(Eqviphead());
                PlayerLibrary.CurrectScaleHead(false, Val);
            }
            if (item.itemAttributes[i].attributeName == "None")
            {
                PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>().addItemToInventory(item.itemID);
                PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>().updateItemList();
                PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>().stackableSettings();

            }
        }
        //if (HPMANACanvas != null)
        //{
        //    UpdateManaBar();
        //    UpdateHPBar();
        //}
    }

    public void OnUnEquipItem(Item item)
    {
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            if (item.itemAttributes[i].attributeName == "Pistol")
            {
                
                RHand.GetComponent<GunSet>().IdGun -= item.itemAttributes[i].attributeValue;
                Spine.GetComponent<GunSet>().IdGun -= item.itemAttributes[i].attributeValue;
                RHand.GetComponent<GunSet>().HideAll();
                Spine.GetComponent<GunSet>().HideAll();
            }
            if (item.itemAttributes[i].attributeName == "Rifle")
            {
              
                RHand.GetComponent<GunSet>().IdRifle -= item.itemAttributes[i].attributeValue;
                Tors.GetComponent<GunSet>().IdRifle -= item.itemAttributes[i].attributeValue;
                RHand.GetComponent<GunSet>().HideAllRifle();
                Tors.GetComponent<GunSet>().HideAllRifle();
            }
            if (item.itemAttributes[i].attributeName == "Body")
            {
                float q = item.itemAttributes[i].attributeValue;
                float Val = ((q) / 100);
                Armor.GetComponent<GunSet>().HideArmor();
                PlayerLibrary.CurrectScaleBody(true, Val);
            }
            if (item.itemAttributes[i].attributeName == "Head")
            {
                float q = item.itemAttributes[i].attributeValue;
                float Val = ((q) / 100);
                Head.GetComponent<GunSet>().HideHrad();
                PlayerLibrary.CurrectScaleHead(true, Val);
            }

        }
        //if (HPMANACanvas != null)
        //{
        //    UpdateManaBar();
        //    UpdateHPBar();
        //}
    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(inputManagerDatabase.InventoryKeyCode))
        {
            if (!inventory.activeSelf)
            {
                mainInventory.openInventory();
            }
            else
            {
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                mainInventory.closeInventory();
            }
        }

        if (Input.GetKeyDown(inputManagerDatabase.CraftSystemKeyCode))
        {
            if (!craftSystem.activeSelf)
                craftSystemInventory.openInventory();
            else
            {
                if (cS != null)
                    cS.backToInventory();
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                craftSystemInventory.closeInventory();
            }
        }

    }

}
