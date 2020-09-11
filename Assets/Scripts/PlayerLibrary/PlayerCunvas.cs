using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerCunvas : MonoBehaviour
{
    public Text Heal;
    public GameObject ActivatedItemSlider;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Heal.text = Convert.ToString(PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.CharacterHealth>().Health) + "/" + Convert.ToString(PlayerLibrary.PlayerGameObject.GetComponent<CoverShooter.CharacterHealth>().MaxHealth);
       
    }
}
