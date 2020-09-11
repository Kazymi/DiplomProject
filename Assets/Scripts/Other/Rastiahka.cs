using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rastiahka : MonoBehaviour
{
    public GameObject Expl;
    public float Dammage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag=="Enemy")
        {
            other.GetComponent<CoverShooter.CharacterHealth>().OnTakenDammage(Dammage);
            GameObject i = Instantiate(Expl);
            i.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
    }
    public void OnHit(CoverShooter.Hit hit)
    {
        GameObject i = Instantiate(Expl);
        i.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }
}
