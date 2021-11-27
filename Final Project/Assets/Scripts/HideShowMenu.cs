using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowMenu : MonoBehaviour
{
    GameObject menu;
   
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("MixedRealityPlayspace/Main Camera/Canvas/MenuBackground");
    }

    public void hideShow()
    {
        if (menu.activeSelf == true)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
    }
}
