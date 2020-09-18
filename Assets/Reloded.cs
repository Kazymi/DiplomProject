using CoverShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reloded : MonoBehaviour
{
    private bool Reload = false;
    private void Update()
    {
        if (Input.GetKey(KeyCode.R) && Reload == false)
        {
            if (GetComponent<Gun>().LoadedBullets < GetComponent<Gun>().MagazineSize)
            {
                PlayerLibrary.PlayerGameObject.GetComponent<Animator>().SetTrigger("LoadMagazine");
                Reload = true;
                StartCoroutine(RelodC());

            }
        }
    }

    IEnumerator RelodC()
    {
        yield return new WaitForSeconds(0.5f);
        Reload = false;
        GetComponent<Gun>().LoadedBullets += 8;
    }
}
