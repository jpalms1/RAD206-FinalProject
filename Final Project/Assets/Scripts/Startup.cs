using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    GameObject wholeBody;
    
    // Start is called before the first frame update
    void Start()
    {
        wholeBody = GameObject.Find("WholeBody");

        //Enable all children of WholeBody
        for (int i = 0; i < wholeBody.transform.childCount; i++)
        {
            wholeBody.transform.GetChild(i).gameObject.SetActive(true);
        }

        //Hide needle sliders and menus at Start
        GameObject.Find("Needle").SetActive(false);
        GameObject.Find("Menu").SetActive(false);
        GameObject.Find("StatusSlate").SetActive(false);
        GameObject.Find("Sliders").SetActive(false);
    }


}
