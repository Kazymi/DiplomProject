using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventDialog : MonoBehaviour
{
    private enum Setting
    {
        TriggerBox = 0,
        Message =1,
        StartAutomatoc =2
    }
    private void Start()
    {
        if (SettingEvent == Setting.StartAutomatoc) StartEvent();
    }

    [SerializeField] private Setting SettingEvent = Setting.Message;
    [SerializeField] private Text TextPanel;
    [SerializeField] private string[] TextMessage;
    [SerializeField] private string[] AvtorText;
    [SerializeField] private AudioClip[] Sound;

    public void StartEvent()
    {
        StartCoroutine(Text());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && SettingEvent == Setting.TriggerBox)
        {
            StartEvent();
        }
    }

    IEnumerator Text()
    {
        Destroy(gameObject.GetComponent<Collider>());
        for (int i = 0; i != TextMessage.Length; i++)
        {
            if (Sound[i] == null) { }
            else
            {
                GetComponent<AudioSource>().clip = Sound[i];
                GetComponent<AudioSource>().Play();
            }
            if (AvtorText[i] == null || AvtorText[i] == "") AvtorText[i] = "Неизвестный";
            TextPanel.text += (""+AvtorText[i]+": ");
            foreach (char j in TextMessage[i])
            {
                TextPanel.text += j;
                yield return new WaitForSeconds(0.1f);              
            }
            yield return new WaitForSeconds(2f);
            TextPanel.text = "";
        }
        Destroy(gameObject);
    }


}
