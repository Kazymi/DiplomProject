using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timerdes : MonoBehaviour
{
    public float Time;
    public bool Destrois;

    private void Start()
    {
        StartCoroutine(Destoii());
    }

    private void Update()
    {
        if (Time == 0) Destroy(gameObject);
    }
    IEnumerator Destoii()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (Destrois) Time--;          
        }
    }
}
