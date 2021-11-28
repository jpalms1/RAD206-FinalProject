using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleCollision : MonoBehaviour
{
    GameObject needle;
    GameObject otherObj;
    Color originalNeedleColor;
    Color originalObjColor;
    public string otherObjName;

    void Start()
    {
        needle = GameObject.Find("MixedRealityPlayspace/Main Camera/Needle");
        originalNeedleColor = needle.GetComponent<Renderer>().material.color;
        otherObjName = "none";
    }

    void OnTriggerEnter(Collider other)
    {
        otherObj = other.gameObject;
        otherObjName = other.gameObject.name;

        if (otherObjName != "Model")
        {
            originalObjColor = otherObj.GetComponent<Renderer>().material.color;

            if (other.gameObject.CompareTag("C-Spine") ||
                other.gameObject.CompareTag("L-Spine") ||
                other.gameObject.CompareTag("T-Spine"))
            {
                otherObj.GetComponent<Renderer>().material.color = Color.red;
               // Debug.Log("Collision w/ " + otherObjName);
            }
            if (other.gameObject.CompareTag("IntervertabralDiscs"))
            {
                otherObj.GetComponent<Renderer>().material.color = Color.gray;

               // Debug.Log("Needle in " + otherObjName);
            }
            if (other.gameObject.CompareTag("SpinalCord"))
            {
                otherObj.GetComponent<Renderer>().material.color = Color.gray;
               // Debug.Log("You hit the " + otherObjName);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Change to original color
        needle.GetComponent<Renderer>().material.color = originalNeedleColor;
        otherObj.GetComponent<Renderer>().material.color = originalObjColor;
    }
}
