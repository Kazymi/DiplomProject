using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnPosition : MonoBehaviour
{
    public GameObject Spawn;
    private void Start()
    {
        StartCoroutine(SpawnC());
    }

    IEnumerator SpawnC()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 25));
            if (transform.childCount == 0) Spawn = null; else Spawn = transform.GetChild(0).gameObject;
        }
    }
}
