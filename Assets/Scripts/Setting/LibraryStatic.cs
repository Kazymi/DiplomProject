using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LibraryStaticSetting
{
    public static bool ActivGlass = true;
    public static bool ActivGrass = true;
    public static bool ActivGils = true;
    public static bool ActivStone = true;
    public static bool ActivHair = true;
    public static bool ActivEffect = true;
}

public class LibrarySetting
{
    public bool ActivGlass = LibraryStaticSetting.ActivGlass;
    public bool ActivGrass = LibraryStaticSetting.ActivGrass;
    public bool ActivGils = LibraryStaticSetting.ActivGils;
    public bool ActivStone = LibraryStaticSetting.ActivStone;
    public bool ActivHair = LibraryStaticSetting.ActivHair;
    public bool ActivEffect = LibraryStaticSetting.ActivEffect;

    public void apply()
    {
        LibraryStaticSetting.ActivGlass = ActivGlass;
        LibraryStaticSetting.ActivGrass = ActivGrass;
        LibraryStaticSetting.ActivGils = ActivGils;
        LibraryStaticSetting.ActivStone = ActivStone;
        LibraryStaticSetting.ActivEffect = ActivEffect;
        LibraryStaticSetting.ActivHair = ActivHair;
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Setting");
        for(int i = 0; i!=gameObjects.Length; i++)
        {
            gameObjects[i].GetComponent<SettingGameObject>().Check();
        }
    }
}
