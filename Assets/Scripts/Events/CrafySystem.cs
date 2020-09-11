using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrafySystem : MonoBehaviour
{
    private bool Activ = false;
    [Header("Панель крафта")] [SerializeField] private GameObject Panel;
    public void E(GameObject Player)
    {
        if (Activ)
        {
            Panel.SetActive(false);
            PlayerLibrary.CraftSystem = false;
            Activ = false;
        }
        else
        {
            Panel.SetActive(true);
            PlayerLibrary.CraftSystem = true;
            Activ = true;
        }
    }
}
