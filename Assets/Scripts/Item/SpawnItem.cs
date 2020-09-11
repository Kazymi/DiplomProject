using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject[] Items;

    [Header("Если шанс не 100%, а 1к3 то ставьте галочку")]
    [SerializeField] private bool SpawnItemHans;
    [SerializeField] private GameObject[] SpawnPosition;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            SpawnItems();
            yield return new WaitForSeconds(360f);
        }
    }
    void SpawnItems()
    {
        for(int i =0; i!=SpawnPosition.Length; i++)
        {
            if (SpawnPosition[i].GetComponent<ItemSpawnPosition>().Spawn == null)
            {
                if(SpawnItemHans)
                if (Random.Range(0, 3) == 2)
                {
                        GameObject SpawnObject = Instantiate(Items[Random.Range(0, Items.Length)]);
                        SpawnObject.transform.SetParent(SpawnPosition[i].transform);
                        SpawnObject.transform.localPosition = Vector3.zero;
                        SpawnObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {

                    }
                else
                {
                    GameObject SpawnObject = Instantiate(Items[Random.Range(0, Items.Length)]);
                    SpawnObject.transform.SetParent(SpawnPosition[i].transform);
                    SpawnObject.transform.localPosition = Vector3.zero;
                    SpawnObject.transform.localRotation = Quaternion.Euler(0, 0, 90);
                }
            }
        }
    }

}
