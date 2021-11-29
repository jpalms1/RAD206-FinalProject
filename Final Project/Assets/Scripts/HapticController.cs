using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticController : MonoBehaviour
{
    float convertToMillimeter = 100.0f;
    public float dorsalCommand;
    public float ventralCommand;

    GameObject needle;
    GameObject needleTipHIP;
    GameObject needleTipGO;

    public Vector3 needleCenterToHIP;
    public Vector3 needleGOToHIP;
    public Vector3 cylinderAxis;
    public float cylinderAxisIsUnit;

    public Vector3 needleTipGOCollision;
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

        if (isGOInDisc == true)
        {
            needleTipGO.transform.position = needleTipGOCollision;

            //Convert value to mm
            dorsalCommand = 0.5f *Vector3.Magnitude(needleGOToHIP) * convertToMillimeter;
            ventralCommand = dorsalCommand;
        }
        else
        {
            needleTipGO.transform.position = needleTipHIP.transform.position;
            dorsalCommand = 0.0f;
            ventralCommand = 0.0f;
        }
    }

    //When the needle tip collides with the disc, freeze the z-position of the tipGO
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Male_Skeletal_Intervertabral_Discs_Geo")
        {
            needleTipGOCollision = needleTipGO.transform.position;
            //Debug.Log((needleTipGO.transform.position).ToString("F4"));

            isGOInDisc = true;
        }
    }

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
