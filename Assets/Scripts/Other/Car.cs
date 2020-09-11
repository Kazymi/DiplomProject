using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    
    [SerializeField] private GameObject[] Light;
    private AudioSource Source;

    void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(GetComponent<BoxCollider>());
            StartCoroutine(LightEnumirator());
            Source.enabled=true;

        }


        IEnumerator LightEnumirator()
        {
            int i = 0;
            while (true)
            {
                LigtSer(true);
                CoverShooter.Alerts.Broadcast(transform.position, 25, false, other.GetComponent<CoverShooter.Actor>(), true);
                yield return new WaitForSeconds(0.24f);
                LigtSer(false);
                yield return new WaitForSeconds(0.24f);
                i++;
                if (i == 23) break;
            }
        }
        void LigtSer(bool Set)
        {
            Light[0].SetActive(Set);
            Light[1].SetActive(Set);
            Light[2].SetActive(Set);
        }
    }
}
