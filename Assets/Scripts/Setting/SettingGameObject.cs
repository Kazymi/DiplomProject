using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingGameObject : MonoBehaviour
{
   public enum SettingObject
    {
        Stone = 0,
        Grass = 1,
        Glass = 2,
        Gils =3,
        Hair = 4,
        effect = 5
    }
    public SettingObject GameObj = SettingObject.Stone;

    public void Check()
    { 
            switch (GameObj)
            {
                case SettingObject.Stone: if (!LibraryStaticSetting.ActivStone) Destroy(gameObject);
                    break;
                case SettingObject.Grass: if (!LibraryStaticSetting.ActivGrass) Destroy(gameObject);
                    break;
                case SettingObject.Glass: if (!LibraryStaticSetting.ActivGlass) Destroy(gameObject);
                    break;
                case SettingObject.Gils: if (!LibraryStaticSetting.ActivGils) Destroy(gameObject);
                    break;
                case SettingObject.effect:
                    if (!LibraryStaticSetting.ActivEffect) Destroy(gameObject);
                break;
        }
    }


}
