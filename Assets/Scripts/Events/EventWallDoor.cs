using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventWallDoor : MonoBehaviour
{
    private bool ActivTrigger;
    private bool ActivButton;
    [SerializeField] private GameObject Light;
    [SerializeField] private Animator Animatordoor;
    private GameObject Other;
    private void Start()
    {
        StartCoroutine(Wall());
        StartCoroutine(TimerDeley());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ActivTrigger = true;
            Other = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ActivTrigger = false;
        }
    }

    public void E(GameObject Player)
    {
        if (ActivButton != true)
        {
            GetComponent<SpawVoln>().Spawn();
            Light.SetActive(true);
            ActivButton = true;
        }

    }

   IEnumerator TimerDeley()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            CoverShooter.Alerts.Broadcast(Other.transform.position, 25, false, Other.GetComponent<CoverShooter.Actor>(), true);
        }
    }
    IEnumerator Wall()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f * Time.deltaTime);
            if (ActivButton && ActivTrigger)
            {
                CheckAnimator(true);
            }
            else CheckAnimator(false);
        }

    }

    private void CheckAnimator(bool Value)
    {
        if (Animatordoor.GetFloat("Blend") >= 0.6) Destroy(Animatordoor.gameObject.GetComponent<Collider>());
        if (Value)
        {
            if (Animatordoor.GetFloat("Blend") >= 1)
            {
                Animatordoor.SetFloat("Blend", 1);
            }
            else
            {
                Animatordoor.SetFloat("Blend", Animatordoor.GetFloat("Blend") + 0.0002f);
                
            }
        }
        else
        {
            if (Animatordoor.GetFloat("Blend") > 0)
            {
                Animatordoor.SetFloat("Blend", Animatordoor.GetFloat("Blend") - 0.001f);
            }
            else
            {
                Animatordoor.SetFloat("Blend", 0);
            }
           
        }

    }
}
