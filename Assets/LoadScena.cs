using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScena : MonoBehaviour
{
    public int NumScena = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") SceneManager.LoadScene(NumScena); 
    }
}
