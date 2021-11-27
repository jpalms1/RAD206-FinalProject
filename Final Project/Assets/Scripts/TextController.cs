using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;
using Microsoft.MixedReality.Toolkit.UI;

public class TextController : MonoBehaviour
{
    GameObject skinModel;
    GameObject boneModel;
    GameObject colonModel;
    GameObject contrastModel;
    GameObject toolModel;

    public TextMeshProUGUI statusText;

    bool twoHandBool;
    bool oneHandBool;

    // Start is called before the first frame update
    void Start()
    {
        skinModel = GameObject.Find("MixedRealityPlayspace/Main Camera/Cube/Body/Skin/Skin");
        boneModel = GameObject.Find("MixedRealityPlayspace/Main Camera/Cube/Body/Bones/Bones");
        colonModel = GameObject.Find("MixedRealityPlayspace/Main Camera/Cube/Body/Colon/Colon");
        contrastModel = GameObject.Find("MixedRealityPlayspace/Main Camera/Cube/Body/Contrast/Contrast");
        toolModel = GameObject.Find("MixedRealityPlayspace/Main Camera/VirtualTool/Capsule");
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<ObjectManipulator>().isActiveAndEnabled == true)
        {
            twoHandBool = true;
            oneHandBool = false;
        }
        else
        {
            twoHandBool = false;
            oneHandBool = true;
        }

        statusText.text = "Skin: " + skinModel.activeSelf.ToString() +
            "\nBones: " + boneModel.activeSelf.ToString() +
            "\nColon: " + colonModel.activeSelf.ToString() +
            "\nContrast: " + contrastModel.activeSelf.ToString() +
            "\nTool: " + toolModel.activeSelf.ToString() +
            "\nOne-Handed: " + oneHandBool.ToString() +
            "\nTwo-Handed: " + twoHandBool.ToString();

    }

}
