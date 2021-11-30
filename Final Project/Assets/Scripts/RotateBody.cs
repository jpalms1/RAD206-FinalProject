using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class RotateBody : MonoBehaviour
{
    GameObject pSlider;
    GameObject body;
    float newSliderValue;
    float oldSliderValue;
    float deltaValue;


    // Start is called before the first frame update
    void Start()
    {
        pSlider = GameObject.Find("PinchSlider_Rot");
        body = GameObject.Find("WholeBody");
    }

    void Update()
    {
        newSliderValue = pSlider.GetComponent<PinchSlider>().SliderValue;
        deltaValue = newSliderValue - oldSliderValue;

        body.transform.Rotate(0.0f, 0.0f, deltaValue * 180.0f, Space.Self);

        oldSliderValue = newSliderValue;

        //Debug.Log("Angle: " + (GetComponent<PinchSlider>().SliderValue * 360.0f).ToString());
    }
}