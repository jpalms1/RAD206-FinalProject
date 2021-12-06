using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowGameObject: MonoBehaviour
{
    GameObject thisObject;

    // Start is called before the first frame update
    void Start()
    {
        thisObject = this.gameObject;
    }

    public void hideShow()
    {
        if (thisObject.activeSelf == true)
        {
            thisObject.SetActive(false);
        }
        else
        {
            thisObject.SetActive(true);
        }
    }
}
