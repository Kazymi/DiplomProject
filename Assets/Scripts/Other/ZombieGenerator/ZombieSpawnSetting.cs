using CoverShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnSetting : MonoBehaviour
{
    public GameObject VolnGenerator;
    public int Number;

    void Start()
    {
        StartCoroutine(CheckNumberZombie());
    }
    IEnumerator CheckNumberZombie()
    {
        while (true) {
            if (!GetComponent<CharacterMotor>().IsAlive)
            {
                VolnGenerator.GetComponent<SpawVoln>().ZombiSpawns--;
                gameObject.AddComponent<DelayedDestroy>().Delay = 10;
                break;
            }
            yield return new WaitForSeconds(2f);
    } }
}
