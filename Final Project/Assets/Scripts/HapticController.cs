using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticController : MonoBehaviour
{
    GameObject needle;
    GameObject needleTipHIP;
    GameObject needleTipGO;
    public Vector3 needleCenterToHIP;
    public Vector3 needleGOToHIP;
    public Vector3 cylinderAxis;
    public float cylinderAxisIsUnit;


    LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        needle = GameObject.Find("MixedRealityPlayspace/Main Camera/Needle");
        needleTipHIP = GameObject.Find("MixedRealityPlayspace/Main Camera/Needle/NeedleTipHIP");
        needleTipGO = GameObject.Find("MixedRealityPlayspace/Main Camera/Needle/NeedleTipGO");

        line = needle.AddComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get the unit vector between HIP and needle center along the axis
        needleCenterToHIP = needleTipHIP.transform.position - needle.transform.position;
        cylinderAxis = needleCenterToHIP/Vector3.Magnitude(needleCenterToHIP);

        cylinderAxisIsUnit = Vector3.Magnitude(cylinderAxis);

        needleGOToHIP = needleTipHIP.transform.position - needleTipGO.transform.position;

        line.useWorldSpace = true;
        line.SetPosition(0, needle.transform.position);
        line.SetPosition(1, needleTipHIP.transform.position);
        line.SetWidth(0.01f, 0.01f);
        line.material.color = Color.red;
    }


    //When the needle tip collides with the disc, freeze the z-position of the tipGO
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Model")
        {
            Vector3 offset = new Vector3(0.0f, 0.0f, -0.1f);

            needleTipGO.transform.position = needleTipHIP.transform.position + 
                Vector3.Dot(offset, cylinderAxis)*cylinderAxis ;
        }
    }

    /*
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name != "Model")
        {
            needleTipGO.transform.position = new Vector3(needleTipGO.transform.position.x,
                needleTipGO.transform.position.y, needleTipGO.transform.position.z - needleTipHIP.transform.position.z);
        }
    }
    */
    void OnTriggerExit(Collider other)
    {
        needleTipGO.transform.position = needleTipHIP.transform.position;
    }

}
