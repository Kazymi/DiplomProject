using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    public GameObject Cunvas;
    public GameObject SettingCunvas;
    void Start()
    {
        Cunvas.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PlayerLibrary.SettingMenu)
        {
            Cunvas.SetActive(!Cunvas.activeSelf);
            PlayerLibrary.ActivEsc = !PlayerLibrary.ActivEsc;
        }
    }

    public void Exit()
    {
        Cunvas.SetActive(!Cunvas.activeSelf);
        PlayerLibrary.ActivEsc = !PlayerLibrary.ActivEsc;
    }

    public void CreateSetting()
    {
        if (!PlayerLibrary.SettingMenu)
        {
            GameObject i = Instantiate(SettingCunvas);
        }
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
    }
}
