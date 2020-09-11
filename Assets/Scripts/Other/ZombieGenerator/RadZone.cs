using CoverShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadZone : MonoBehaviour
{
    [Header("Урон от зоны")]
    [SerializeField] private int Dammage = 10;
    [SerializeField] private GameObject SoundCrouch;

    private bool _PlayerInZone;
    private void Start()
    {
        StartCoroutine(DammagePlayer(PlayerLibrary.PlayerGameObject));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") _PlayerInZone = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") _PlayerInZone = false;
    }

    IEnumerator DammagePlayer(GameObject other)
    {
        while (true)
        {
            if(_PlayerInZone == false) { } else
            if (other.tag == "Player" || other.tag == "Enemy")
            {
                other.GetComponent<CoverShooter.CharacterHealth>().OnTakenDammage(Dammage);
                GameObject Sound = Instantiate(SoundCrouch, other.transform);
                Sound.AddComponent<DelayedDestroy>().Delay = 3;
                Sound.transform.SetParent(other.transform);
                Sound.transform.localPosition = Vector3.zero;
            }
            yield return new WaitForSeconds(2f);
        }
    }

}
