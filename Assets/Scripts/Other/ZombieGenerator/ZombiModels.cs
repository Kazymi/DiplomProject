using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiModels : MonoBehaviour
{
        [Header("Основной зомби.")]
    public GameObject Zombis;
        [Header("Количество")]
    public int Count = 5;
        [Header("Особый зомби?")] public bool ZombiBoss;
        [Header("Особые зомби")] public ZombieBoss[] Boss;
        [Header("Точки появления.")] public Transform[] PositionSpawn;
}
