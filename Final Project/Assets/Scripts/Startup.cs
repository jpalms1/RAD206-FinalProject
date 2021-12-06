using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    GameObject wholeBody;
    GameObject sliders;

    // Start is called before the first frame update
    void Start()
    {
        wholeBody = GameObject.Find("WholeBody");
        sliders = GameObject.Find("Sliders");

        //Enable all children of WholeBody
        for (int i = 0; i < wholeBody.transform.childCount; i++)
        {
            wholeBody.transform.GetChild(i).gameObject.SetActive(true);
        }

        //Hide Sliders at Start
        sliders.SetActive(false);
    }


}
