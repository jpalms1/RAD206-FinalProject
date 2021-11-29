using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodObjectController : MonoBehaviour
{
    //Fill in in Inspector tab
    [Header("Adjustable Settings")]
    public GameObject targetHapticObject;
    public float stiffness;
    public int hapticTargetBoolIndex;

    [Header("Device")]
    public float dorsalCommand;
    public float ventralCommand;
    float convertToMillimeter = 100.0f;

    [Header("Needle Info")]
    public Vector3 thisGOToHIP;
    public bool isNeedleInTarget;
    GameObject needleTipHIP;

    [Header("God Object Info")]
    public Vector3 collisionPoint;
    public Vector3 needleTipHIPPosition;
    public Vector3 thisPosition;
    public bool isGOInside;

    // Start is called before the first frame update
    void Start()
    {
        needleTipHIP = GameObject.Find("NeedleTipHIP");

        isGOInside = false;
        isNeedleInTarget = false;

        dorsalCommand = 0.0f;
        ventralCommand = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        needleTipHIPPosition = needleTipHIP.transform.position;

        thisGOToHIP = transform.position - needleTipHIPPosition;
        thisPosition = transform.position;

        isNeedleInTarget = GameObject.Find("Needle").GetComponent<HapticController>().hapticTargetBools[hapticTargetBoolIndex];

        if (isNeedleInTarget == true)
        {
            transform.position = collisionPoint;

            //Convert value to mm
            dorsalCommand = stiffness * Vector3.Magnitude(thisGOToHIP) * convertToMillimeter;
            ventralCommand = dorsalCommand;
        }
        else
        {
            transform.position = needleTipHIPPosition;
            dorsalCommand = 0.0f;
            ventralCommand = 0.0f;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetHapticObject.tag))
        {
            collisionPoint = transform.position;
            //Debug.Log((needleTipGO.transform.position).ToString("F4"));

            isGOInside = true;
            isNeedleInTarget = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(targetHapticObject.tag))
        {
            isGOInside = false;
            isNeedleInTarget = false;
        }
        transform.position = needleTipHIPPosition;

        //Convert value to mm
        dorsalCommand = 0.0f;
        ventralCommand = 0.0f;
    }
}
