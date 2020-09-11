using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSetting : MonoBehaviour
{
    public LibrarySetting Library = new LibrarySetting();


    private void Start()
    {
        PlayerLibrary.SettingMenu = true;
    }

    public void DGrass()
    {
        Library.ActivGrass = false;
    }

    public void OGrass()
    {
        Library.ActivGrass = true;
    }

    public void OGlass()
    {
        Library.ActivGlass = true;
    }
    public void DGlass()
    {
        Library.ActivGlass = false;
    }

    public void OStone()
    {
        Library.ActivStone = true;
    }
    public void DStone()
    {
        Library.ActivStone = false;
    }
    
    public void OGild()
    {
        Library.ActivGils = true;
    }
    public void DGild()
    {
        Library.ActivGils = false;
    }
    public void Close()
    {
        PlayerLibrary.SettingMenu = false;
        Destroy(gameObject);
    }
    public void Appli()
    {
        Library.apply();
        Close();
    }
}
