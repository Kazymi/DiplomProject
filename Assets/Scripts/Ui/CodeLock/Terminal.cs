using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : MonoBehaviour
{
    [SerializeField] private Text TextIu;
    public Animator animator;
    private AudioSource source;
    [SerializeField] private GameObject SoundButton;
    [SerializeField] private AudioClip[] audioClips = new AudioClip[4];
    public string Password = "12345";
    private void Start()
    {
        PlayerLibrary.CraftSystem = true;
        source = GetComponent<AudioSource>();
    }
    public void ButtonI(int Num)
    {
        if(TextIu.text.Length != 6)
        TextIu.text += Num;
        SpawnButton(audioClips[1]);
    }
    

    public void CheckPassword()
    {
        if(TextIu.text == Password)
        {
            animator.SetTrigger("Open");
            PlayerLibrary.CraftSystem = false;
            Destroy(gameObject);

            SpawnButton(audioClips[0]);
            
        }
        else
        {

            SpawnButton(audioClips[2]);

            Destroy(gameObject);
            PlayerLibrary.CraftSystem = false;
        }
    }

    public void DelString()
    {
        if(TextIu.text.Length != 0)
        {

            SpawnButton(audioClips[1]);

            string i = TextIu.text;
            string NewText = "";
            for (int j = 0; j != i.Length-1; j++)
            {
                NewText += i[j];
            }
            TextIu.text = NewText;
        }
    }
    private void SpawnButton(AudioClip clip)
    {
        GameObject ClipsSourse = Instantiate(SoundButton);
        ClipsSourse.GetComponent<AudioSource>().clip = clip;
        ClipsSourse.GetComponent<AudioSource>().Play();
    }
}
