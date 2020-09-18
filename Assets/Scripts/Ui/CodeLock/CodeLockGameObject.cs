using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLockGameObject : MonoBehaviour
{
    [SerializeField] private GameObject ins;
    [SerializeField] private Animator animator;
    [SerializeField] private string Password = "12345";

    private GameObject NewObect;

    public void E(GameObject Player)
    {
        if(NewObect == null)
        {
            NewObect = Instantiate(ins);
            NewObect.GetComponent<Terminal>().animator = animator;
            NewObect.GetComponent<Terminal>().Password = Password;
            NewObect.GetComponent<Terminal>().CodeLockGameObject = gameObject;
        }
    }
}
