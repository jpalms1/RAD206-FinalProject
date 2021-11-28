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
        pSlider = GameObject.Find("MixedRealityPlayspace/Main Camera/PinchSlider");
        body = GameObject.Find("MixedRealityPlayspace/Main Camera/Model/WholeBody");
    }

    void Update()
    {
        newSliderValue = pSlider.GetComponent<PinchSlider>().SliderValue;
        deltaValue = newSliderValue - oldSliderValue;

        body.transform.Rotate(0.0f, 0.0f, deltaValue * 360.0f, Space.Self);

        oldSliderValue = newSliderValue;

        //Debug.Log("Angle: " + (GetComponent<PinchSlider>().SliderValue * 360.0f).ToString());
    }






}
/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class RotateBody : MonoBehaviour
{
GameObject pSlider;
GameObject skin;
GameObject bones;
GameObject colon;
GameObject contrast;

float newSliderValue;
float oldSliderValue;
float deltaValue;


// Start is called before the first frame update
void Start()
{
    pSlider = GameObject.Find("MixedRealityPlayspace/Main Camera/PinchSlider");
    skin = GameObject.Find("MixedRealityPlayspace/Main Camera/Body/Skin");
    bones = GameObject.Find("MixedRealityPlayspace/Main Camera/Body/Bones");
    colon = GameObject.Find("MixedRealityPlayspace/Main Camera/Body/Colon");
    contrast = GameObject.Find("MixedRealityPlayspace/Main Camera/Body/Contrast");
}

void Update()
{
    newSliderValue = pSlider.GetComponent<PinchSlider>().SliderValue;
    deltaValue = newSliderValue - oldSliderValue;

    skin.transform.Rotate(0.0f, deltaValue * 360.0f, 0.0f, Space.Self);
    bones.transform.Rotate(0.0f, deltaValue * 360.0f, 0.0f, Space.Self);
    colon.transform.Rotate(0.0f, deltaValue * 360.0f, 0.0f, Space.Self);
    contrast.transform.Rotate(0.0f, deltaValue * 360.0f, 0.0f, Space.Self);

    oldSliderValue = newSliderValue;

    //Debug.Log("Angle: " + (GetComponent<PinchSlider>().SliderValue * 360.0f).ToString());
}
}



 */