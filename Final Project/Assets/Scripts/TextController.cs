using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;
using Microsoft.MixedReality.Toolkit.UI;

public class TextController : MonoBehaviour
{
    GameObject cSpineModel;
    GameObject lSpineModel;
    GameObject tSpineModel;
    GameObject discsModel;
    GameObject spinalCordModel;
    GameObject sacrumModel;

    public TextMeshProUGUI statusText;

    string manipulationType;

    // Start is called before the first frame update
    void Start()
    {
        cSpineModel = GameObject.Find("MixedRealityPlayspace/Main Camera/Model/WholeBody/Skeleton/C-Spine");
        lSpineModel = GameObject.Find("MixedRealityPlayspace/Main Camera/Model/WholeBody/Skeleton/L-Spine");
        tSpineModel = GameObject.Find("MixedRealityPlayspace/Main Camera/Model/WholeBody/Skeleton/T-Spine");
        discsModel = GameObject.Find("MixedRealityPlayspace/Main Camera/Model/WholeBody/Skeleton/Male_Skeletal_Intervertabral_Discs_Geo");
        spinalCordModel = GameObject.Find("MixedRealityPlayspace/Main Camera/Model/WholeBody/Organs/Nervous_Brain_Stem_Geo");
        sacrumModel = GameObject.Find("MixedRealityPlayspace/Main Camera/Model/WholeBody/Skeleton/Male_Skeletal_Sacrum_Geo");
        
        manipulationType = "Two-Handed";
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<ObjectManipulator>().isActiveAndEnabled == true)
        {
            manipulationType = "Two-Handed";
        }
        else
        {
            manipulationType = "One-Handed";
        }

        statusText.text = "<size=22>Status:</size>" +
            "\nC-Spine: " + cSpineModel.activeSelf.ToString() +
            "\nT-Spine: " + tSpineModel.activeSelf.ToString() +
            "\nL-Spine: " + lSpineModel.activeSelf.ToString() +
            "\nDiscs: " + discsModel.activeSelf.ToString() +
            "\nSpinal Cord: " + spinalCordModel.activeSelf.ToString() +
            "\nSacrum: " + sacrumModel.activeSelf.ToString() + 
            "\nManip Type: " + manipulationType;
    }

}
