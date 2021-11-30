using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class TransformBody : MonoBehaviour
{
    GameObject pSliderRot;
    GameObject pSliderTransX;
    GameObject pSliderTransY;
    GameObject pSliderTransZ;

    GameObject body;

    float newSliderValueRot;
    float oldSliderValueRot;
    float deltaValueRot;

    float newSliderValueX;
    float oldSliderValueX;
    float deltaValueX;
    
    float newSliderValueY;
    float oldSliderValueY;
    float deltaValueY;

    float newSliderValueZ;
    float oldSliderValueZ;
    float deltaValueZ;

    // Start is called before the first frame update
    void Start()
    {
        pSliderRot = GameObject.Find("PinchSlider_Rot");
        pSliderTransX = GameObject.Find("PinchSlider_TransX");
        pSliderTransY = GameObject.Find("PinchSlider_TransY");
        pSliderTransZ = GameObject.Find("PinchSlider_TransZ");
        body = GameObject.Find("Model");
    }

    void Update()
    {
        rotateBody();
        translateBody();
    }

    void rotateBody()
    {
        newSliderValueRot = pSliderRot.GetComponent<PinchSlider>().SliderValue;
        deltaValueRot = newSliderValueRot - oldSliderValueRot;

        body.transform.Rotate(0.0f, 0.0f, deltaValueRot * 360.0f, Space.Self);

        oldSliderValueRot = newSliderValueRot;
    }

    void translateBody()
    {
        newSliderValueX = pSliderTransX.GetComponent<PinchSlider>().SliderValue;
        deltaValueX = newSliderValueX - oldSliderValueX;
        
        newSliderValueY = pSliderTransY.GetComponent<PinchSlider>().SliderValue;
        deltaValueY = newSliderValueY - oldSliderValueY;
        
        newSliderValueZ = pSliderTransZ.GetComponent<PinchSlider>().SliderValue;
        deltaValueZ = newSliderValueZ - oldSliderValueZ;

        Vector3 temp = new Vector3(deltaValueX, deltaValueY, deltaValueZ);
        body.transform.position += temp;

        //Debug.Log("pos: " + (body.transform.position).ToString());

        oldSliderValueX = newSliderValueX;
        oldSliderValueY = newSliderValueY;
        oldSliderValueZ = newSliderValueZ;
    }
}