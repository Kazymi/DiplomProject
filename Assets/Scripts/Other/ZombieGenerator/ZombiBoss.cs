using CoverShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiBoss : MonoBehaviour
{
    public int TimeDestroi = 10;
    public GameObject ZoneR;
    public bool Activ = false;
    private CharacterMotor Motor;

    private void Start()
    {
        Motor = GetComponent<CharacterMotor>();
        StartCoroutine(Check());
    }

    IEnumerator Check()
    {
        while (true)
        {
            if (Motor.IsAlive)
            {

            }
            else
            {
                Activ = true;
                ZoneR.SetActive(true);
                ZoneR.AddComponent<DelayedDestroy>().Delay = TimeDestroi;
                break;
            }
            yield return new WaitForSeconds(2f);
        }
    }
}

