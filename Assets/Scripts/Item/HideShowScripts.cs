using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowScripts : MonoBehaviour
{
    [SerializeField] private Behaviour[] Components;
    
    public void Hide()
    {
        for(int i =0; i!= Components.Length; i++)
        {
            Components[i].enabled = false;
        }
    }
    public void Show()
    {
        for (int i = 0; i != Components.Length; i++)
        {
            Components[i].enabled = true;
        }
    }
}
