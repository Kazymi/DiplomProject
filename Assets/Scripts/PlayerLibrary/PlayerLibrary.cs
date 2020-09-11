using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerLibrary 
{
    public static GameObject PlayerGameObject;
    public static GameObject GunInHand;
    public static bool UseItem = false;
    public static bool ActivDialog = false;
    public static bool ActivEsc = false;
    public static bool SettingMenu =false;

    public static GameObject Head;
    public static GameObject Body;

    public static float DammageScaleBody = 0;
    public static float DammageScaleHead = 0;

    


    public static void CurrectScaleBody(bool i,float Value)
    {
        if (i)
        {
           
            Body.GetComponent<CharaCurrectScale.CharaPartCur>().ScaleUpdate(Value, i);
        }
        else
        {
            
            Body.GetComponent<CharaCurrectScale.CharaPartCur>().ScaleUpdate(Value, i);
        }
    }

    public static void CurrectScaleHead(bool i, float Value)
    {
        if (i)
        {
            
            Head.GetComponent<CharaCurrectScale.CharaPartCur>().ScaleUpdate(Value, i);
        }
        else
        {
          
            Head.GetComponent<CharaCurrectScale.CharaPartCur>().ScaleUpdate(Value, i);
        }
    }
    


}
