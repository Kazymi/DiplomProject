using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gromkog : MonoBehaviour
{
    [SerializeField] GameObject Sound;
    private void Update()
    {
        if (Sound.GetComponent<CoverShooter.CharacterMotor>().IsAlive == false) Destroy(gameObject); 
    }
    public void E(GameObject d)
    {
        if (Sound == null) return;
        Sound.SetActive(!Sound.activeSelf);
       
    }

    
}
