using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleCollision : MonoBehaviour
{
    GameObject needle;
    Color originalColor;
    public string otherObj;


    void Start()
    {
        needle = GameObject.Find("MixedRealityPlayspace/Main Camera/Needle");
        originalColor = needle.GetComponent<Renderer>().material.color;
        otherObj = "none";
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("C-Spine"))
        {
            needle.GetComponent<Renderer>().material.color = Color.red;
        }
        if (other.gameObject.CompareTag("test"))
        {
            needle.GetComponent<Renderer>().material.color = Color.blue;
        }
        otherObj = other.gameObject.name;
        Debug.Log(otherObj);
    }

    void OnTriggerExit(Collider other)
    {
        // Change to original color
        if (other.gameObject.CompareTag("C-Spine"))
        {
            needle.GetComponent<Renderer>().material.color = originalColor;
        }
        if (other.gameObject.CompareTag("test"))
        {
            needle.GetComponent<Renderer>().material.color = originalColor;
        }
    }
}
