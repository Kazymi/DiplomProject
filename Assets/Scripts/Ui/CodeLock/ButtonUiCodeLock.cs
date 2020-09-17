using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUiCodeLock : MonoBehaviour
{
   private enum Buttons
    {
       _0 = 0,
       _1 = 1,
       _2 = 2,
       _3 = 3,
       _4 = 4,
       _5 = 5,
       _6 = 6,
       _7 = 7,
       _8 = 8,
       _9 = 9,
       _Ok = 10,
       _Del = 11
       
    }

    [SerializeField] private Terminal LockBlock;
    [SerializeField] private Buttons Buttond = Buttons._0;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonClick);
    }

    public void ButtonClick()
    {
        switch (Buttond)
        {
            case Buttons._0:
                LockBlock.ButtonI(0); break;
            case Buttons._1:
                LockBlock.ButtonI(1); break;
            case Buttons._2:
                LockBlock.ButtonI(2); break;
            case Buttons._3:
                LockBlock.ButtonI(3); break;
            case Buttons._4:
                LockBlock.ButtonI(4); break;
            case Buttons._5:
                LockBlock.ButtonI(5); break;
            case Buttons._6:
                LockBlock.ButtonI(6); break;
            case Buttons._7:
                LockBlock.ButtonI(7); break;
            case Buttons._8:
                LockBlock.ButtonI(8); break;
            case Buttons._9:
                LockBlock.ButtonI(9); break;
            case Buttons._Ok:
                LockBlock.CheckPassword(); break;
            case Buttons._Del:
                LockBlock.DelString(); break;
        }
    }
}
