using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawVoln : MonoBehaviour
{
    [Header("Волны. Настройка")]
    public ZombiModels[] WavesCount;
    public int CurrentWaves = 0;
    public int MaxZombieSpawn = 10;

    public int ZombiSpawns = 0;

    public void Spawn()
    {
        StartCoroutine(SpawnCur());
    }

    IEnumerator SpawnCur()
    {
        int Currs = 0;
        if (WavesCount[CurrentWaves].ZombiBoss)
        {
            StartCoroutine(SpawnBoss());
        }
        while (Currs != WavesCount[CurrentWaves].Count)
        {
            yield return new WaitForSeconds(1f);
            if (ZombiSpawns != MaxZombieSpawn)
            {
                GameObject Zombie = Instantiate(WavesCount[CurrentWaves].Zombis, WavesCount[CurrentWaves].PositionSpawn[Random.Range(0, WavesCount[CurrentWaves].PositionSpawn.Length)].transform);
                Zombie.transform.localPosition = new Vector3(0, 0, 0);
                Currs++;
                ZombiSpawns++;
                Zombie.AddComponent<ZombieSpawnSetting>().VolnGenerator = gameObject;
                Zombie.GetComponent<ZombieSpawnSetting>().Number = ZombiSpawns;
            }
        }
        CurrentWaves++;
        IEnumerator SpawnBoss()
        {
            int Curr = 0;
            while (Curr != WavesCount[CurrentWaves].Boss.Length)
            {
               
                    StartCoroutine(spawnBossCurr(WavesCount[CurrentWaves].Boss[Curr]));
                    Curr++;
                    Debug.Log("SpawnBoss");
                   
                
                yield return new WaitForSeconds(7f);
            }

            IEnumerator spawnBossCurr(ZombieBoss Boss)
            {
                int CurrD = 0;
                while (CurrD != Boss.BossCount)
                {
                    yield return new WaitForSeconds(4f);
                    if (ZombiSpawns != MaxZombieSpawn)
                    {
                        GameObject Zombie = Instantiate(Boss.BossZombie, Boss.PositionSpawnBoss[Random.Range(0, Boss.PositionSpawnBoss.Length)].transform);
                        Zombie.transform.localPosition = new Vector3(0, 0, 0);
                        CurrD++;
                        Zombie.AddComponent<ZombieSpawnSetting>().VolnGenerator = gameObject;
                        Zombie.GetComponent<ZombieSpawnSetting>().Number = ZombiSpawns;
                        ZombiSpawns++;
                    }
                }
            }
        }
    }
}