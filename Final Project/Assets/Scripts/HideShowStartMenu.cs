using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowStartMenu : MonoBehaviour
{
    GameObject startMenu;
   
    // Start is called before the first frame update
    void Start()
    {
        startMenu = GameObject.Find("MixedRealityPlayspace/Main Camera/Canvas/StartMenuBackground");
    }

    public void hideShow()
    {
        if (startMenu.activeSelf == true)
        {
            startMenu.SetActive(false);
        }
        else
        {
            startMenu.SetActive(true);
        }
    }
}
