using CoverShooter;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public class ZombiCloth : MonoBehaviour
{
    //список для выбора пола, на случай если спаун определен изначально.
    private enum Pol
    {
        M = 0,
        D = 1
    }
    [Header("Пол")] [SerializeField] private Pol PolEnemy = Pol.M;
    [Header("Рандомный пол?")] [SerializeField] private bool PolRandom = false;
    [Header("Модели персонажа, первое Мужские, второе Женские")]
    [SerializeField] private GameObject[] MenCloth;
    [SerializeField] private GameObject[] WomenCloth;
    [Header("Волосы, первое Мужские, второе Женские")]
    [SerializeField] private GameObject[] MenHair;
    [SerializeField] private GameObject[] WomenHair;
    [Header("Борода, только для мужских персон")]
    [SerializeField] private GameObject[] Beard;
    [Header("Маски, редкий атрибут спауна.")]
    [SerializeField] private GameObject[] Mask;

    private void Start()
    {
        HpSpeedGen();
        PolGenerator();
        ClothGenerator();
        GeneratorHair();
        if (PolEnemy == Pol.M) GeneratorBeard();
        GeneratorMask();
    }
    //генератор скорости и хп.
    private void HpSpeedGen()
    {
        CharacterMotor motor = GetComponent<CharacterMotor>();
        motor.Speed = Random.Range(0.8f, 2f);
        CharacterHealth health = GetComponent<CharacterHealth>();
        health.MaxHealth = Random.Range(50, 200);
        health.Health = health.MaxHealth;
        //генератор рандомного роста. 
        transform.localScale = new Vector3(Random.Range(0.9f, 1.1f), Random.Range(0.9f, 1.1f), 1);
    }
    //генератор пола.
    private void PolGenerator()
    {
        int Num = Random.Range(0, 2);
        if (Num == 1) PolEnemy = Pol.D; else PolEnemy = Pol.M;
    }
    //Рандомный генератор одежды. 
    private void ClothGenerator()
    {
        if(PolRandom) // проверка на случай если пол определн изначально
            //генератор для М
            if (PolEnemy == Pol.M)
        {
            int NumberCloth = Random.Range(0, MenCloth.Length);
            MenCloth[NumberCloth].SetActive(true);
        }
        //генератор для Ж
        else
        {
            int NumberCloth = Random.Range(0, WomenCloth.Length);
            WomenCloth[NumberCloth].SetActive(true);
        }
    }
    //Рандомный генератор волос и кепок.
    private void GeneratorHair()
    {
        int Generator = Random.Range(0, 100);
        if(Generator <= 25)
       if(PolEnemy == Pol.D)
        {    
            int NumberHair = Random.Range(0, WomenHair.Length); if(WomenHair[NumberHair] != null)
            WomenHair[NumberHair].SetActive(true);
        }
        else
        {
            int NumberHair = Random.Range(0, MenHair.Length); if (MenHair[NumberHair] != null)
            MenHair[NumberHair].SetActive(true);
        }
    }
    //генератор бород
    private void GeneratorBeard()
    {
        int Generator = Random.Range(0, 100);
        if (Generator <= 50)
            {
                int NumberBread = Random.Range(0, Beard.Length);
                Beard[NumberBread].SetActive(true);
            }
    }
    //генератор масок
    private void GeneratorMask()
    {
        int Generator = Random.Range(0, 100);
        if (Generator <= 60)
        {
            int NumberMask = Random.Range(0, Mask.Length);
            Mask[NumberMask].SetActive(true);
        }
    }
}
