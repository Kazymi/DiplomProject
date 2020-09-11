using Aura2API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryBaseGanerator : MonoBehaviour
{
    private enum Elements
    {
        Terminal = 0,
        Light = 1,
        Sound = 2
    }

    [Header("Элемент обьекта.")]
    [SerializeField] private Elements elements = Elements.Terminal;
    [Header("Элементы запуска")]
    [SerializeField] private GameObject[] GameObjectsForTakeMassage;

    //прием сообщения от игрока
    public void E(GameObject Player)
    {
        if (elements == Elements.Terminal)
        {
            for (int i = 0; i != GameObjectsForTakeMassage.Length; i++)
            {
                GameObjectsForTakeMassage[i].GetComponent<MilitaryBaseGanerator>().StartEvent();
            }
           Destroy(gameObject.GetComponent<Collider>());
        }
    }

    public void StartEvent()
    {
        if(elements == Elements.Light)
        {
            GetComponent<Light>().enabled = true;
            GetComponent<AuraLight>().enabled = true;
        }

        if(elements == Elements.Sound)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
