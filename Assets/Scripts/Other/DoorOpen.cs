using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private enum OpenSystem
    {
        Button = 0,
        Avtomatik = 1,
            Close = 2
    }


    [SerializeField] private OpenSystem DoorSystems = OpenSystem.Button;
    [Header("ClipOpenAndClose")]
    [SerializeField] private AudioClip[] SoundClips;
    private AudioSource Audiosource;
    private Animator Animators;
    [Header("IsOpen")]
    private bool IsOpen = true;
    [Header("OpenDoor")]
    public bool OpenDoor = false;

   IEnumerator Open()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (OpenDoor)
            {
                OpenDoor = false;
                E(null);
            }
        }
    } 


    void Start()
    {
        //куратина для оптимизации кода, на открытие двери через инспектор. Todo: Удалить после тестов.Жрет оптимизацию
        StartCoroutine(Open());
        //
        Audiosource = GetComponent<AudioSource>();
        Animators = GetComponent<Animator>();
    }
    //Сообщения от игрока. 
    public void E(GameObject Player)
    {
        if(DoorSystems == OpenSystem.Button)
        if (IsOpen)
        {
            IsOpen = false;
            Audiosource.clip = SoundClips[0];
            Audiosource.Play();
            Animators.SetTrigger("Open");
            
        }
        else
        {
            IsOpen = true;
            Audiosource.clip = SoundClips[1];
            Audiosource.Play();
            Animators.SetTrigger("Close");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && DoorSystems == OpenSystem.Avtomatik) {
            IsOpen = false;
            Audiosource.clip = SoundClips[0];
            Audiosource.Play();
            Animators.SetTrigger("Open");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && DoorSystems == OpenSystem.Avtomatik)
        {
            IsOpen = true;
            Audiosource.clip = SoundClips[1];
            Audiosource.Play();
            Animators.SetTrigger("Close");
        }
    }


}
