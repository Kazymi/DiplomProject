using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WavesStartSignal : MonoBehaviour
{
    [Header("Волна")] [SerializeField] private SpawVoln Volns;
    [Header("Audio clips")] [SerializeField] private AudioClip[] clips = new AudioClip[3];
    private AudioSource _sourse;
    [Header("Таймер")] [SerializeField] private Text timer;

    private void Start()
    {
        _sourse = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { StartCoroutine(StartTimer()); Destroy(GetComponent<BoxCollider>()); }
    }

    IEnumerator StartTimer()
    {
        int timerS = 60;
        while (timerS != 0)
        {
            if (timerS == 60) { _sourse.clip = clips[0]; _sourse.Play(); }
            if (timerS == 30) { _sourse.clip = clips[1]; _sourse.Play(); }
            if (timerS == 11) { _sourse.clip = clips[2]; _sourse.Play(); }
            yield return new WaitForSeconds(1f);
            timerS--;
            timer.text = Convert.ToString(timerS);
        }
        Destroy(timer);
        Volns.Spawn();
    }
}
