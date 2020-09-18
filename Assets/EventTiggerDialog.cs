using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTiggerDialog : MonoBehaviour
{
    [SerializeField] private GameObject DialogEvent;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            DialogEvent.SetActive(true);
            Destroy(GetComponent<Collider>());
        }
    }
}
