using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticController : MonoBehaviour
{
    float convertMeterToMillimeter = 1000.0f;

    GameObject needle;
    GameObject needleTipHIP;
    GameObject needleTipGO;
    public Vector3 needleCenterToHIP;
    public Vector3 needleGOToHIP;
    public Vector3 cylinderAxis;
    public float cylinderAxisIsUnit;

    public float dorsalCommand;
    public float ventralCommand;

    Ray needleTipGORay;
    RaycastHit hitInfo;
    public LayerMask discMask;
    public float maxDistance = 0.3f;

    public bool isGOInDisc;

    // Start is called before the first frame update
    void Start()
    {
        needle = GameObject.Find("MixedRealityPlayspace/Main Camera/Needle");
        needleTipHIP = GameObject.Find("MixedRealityPlayspace/Main Camera/Needle/NeedleTipHIP");
        needleTipGO = GameObject.Find("MixedRealityPlayspace/Main Camera/Needle/NeedleTipGO");

        dorsalCommand = 0.0f;
        ventralCommand = 0.0f;

        isGOInDisc = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get the unit vector between HIP and needle center along the axis
        needleCenterToHIP = needleTipHIP.transform.position - needle.transform.position;
        cylinderAxis = needleCenterToHIP / Vector3.Magnitude(needleCenterToHIP);
        cylinderAxisIsUnit = Vector3.Magnitude(cylinderAxis);

        needleGOToHIP = needleTipGO.transform.position - needleTipHIP.transform.position;

        //Draw NeedleCenterToHIPLine
        Debug.DrawLine(needle.transform.position, needleTipHIP.transform.position, Color.cyan);

        //Define ray from needleGO to Discs along cylinderAxis
        needleTipGORay = new Ray(needleTipGO.transform.position, cylinderAxis);

        //if ray collides with an object in discs layer
        if (Physics.Raycast(needleTipGORay, out hitInfo, maxDistance, discMask))
        {
            //Draw line to ray contact point
            Debug.DrawLine(needleTipGORay.origin, hitInfo.point, Color.red);
            //needleTipGO.transform.position = hitInfo.point;
        }
        else
        {
            //Draw ray outward 
            Debug.DrawLine(needleTipGORay.origin, needleTipGORay.origin + maxDistance*needleTipGORay.direction, Color.green);
            //needleTipGO.transform.position = needleTipHIP.transform.position;
        }
    }


    //When the needle tip collides with the disc, freeze the z-position of the tipGO
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Male_Skeletal_Intervertabral_Discs_Geo")
        {
            //Keep GO on surface of mesh
            needleTipGO.transform.position = hitInfo.point;
            isGOInDisc = true;
        }
    }

/*
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Male_Skeletal_Intervertabral_Discs_Geo")
        {
            //Keep GO on surface of mesh
            needleTipGO.transform.position = hitInfo.point;
        }
    }
    //    */
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Male_Skeletal_Intervertabral_Discs_Geo")
        {
            isGOInDisc = false;
        }
        needleTipGO.transform.position = needleTipHIP.transform.position;

        //Convert value to mm
        dorsalCommand = 0.0f;
        ventralCommand = 0.0f;
    }


}
