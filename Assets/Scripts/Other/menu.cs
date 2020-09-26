using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] private GameObject UiCunvas;

    [SerializeField] private GameObject UiCunvasMain;
    [SerializeField] private GameObject[] UiCunvasStartGame;

    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject[] PositionCamera;
    public void StartGame()
    {
        UiCunvas.SetActive(true);
    }

    public void PositionCameraUpdate_1()
    {
        UdateCameraPos("One");
        UiCunvasMain.SetActive(false);
        UiCunvasStartGame[0].SetActive(true);
    }

    public void PositionCameraUpdate_2()
    {
        UdateCameraPos("Two");
        UiCunvasMain.SetActive(false);
        UiCunvasStartGame[1].SetActive(true);
    }

    public void StartGame_1()
    {
        SceneManager.LoadScene(3);
    }

    public void StartGame_2()
    {
        SceneManager.LoadScene(3);
    }
    public void Back()
    {
        UiCunvasMain.SetActive(true);
        UiCunvasStartGame[0].SetActive(false);
        UiCunvasStartGame[1].SetActive(false);
        UiCunvasStartGame[2].SetActive(false);
        ResetAnimatrion();
    }

   void UdateCameraPos(string i)
    {
        Camera.GetComponent<Animator>().SetBool(i, true);
        UiCunvas.SetActive(false);
    }

  private void ResetAnimatrion()
    {
        Camera.GetComponent<Animator>().SetBool("One", false);
        Camera.GetComponent<Animator>().SetBool("Two", false);
        Camera.GetComponent<Animator>().SetBool("Tree", false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartPoligon()
    {
        SceneManager.LoadScene(2);
    }
}
