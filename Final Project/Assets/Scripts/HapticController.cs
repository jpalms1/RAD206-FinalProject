using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticController : MonoBehaviour
{
    public GameObject[] hapticTargets;

    public float totalDorsalCommand;
    public float totalVentralCommand;

    GameObject needle;
    GameObject needleTipHIP;
    GameObject needleTipGO;

    public Vector3 cylinderAxis;
    public float cylinderAxisIsUnit;

    public bool[] hapticTargetBools;
    bool isNeedleInSkin;
    bool isNeedleInMuscle;
    bool isNeedleInDisc;
    bool isNeedleInStem;

    public Vector3 needleCenterToHIP;
    public Vector3 needleGOToHIP;
    public Vector3 needleTipHIPPosition;

    // Start is called before the first frame update
    void Start()
    {
        hapticTargets = new GameObject[] {            
            GameObject.Find("skin"),
            GameObject.Find("Muscle"),
            GameObject.Find("Male_Skeletal_Intervertabral_Discs_Geo"),
            GameObject.Find("Nervous_Brain_Stem_Geo")};
        hapticTargetBools = new bool[4];

        needle = GameObject.Find("Needle");
        needleTipHIP = GameObject.Find("NeedleTipHIP");

        totalDorsalCommand = 0.0f;
        totalVentralCommand = 0.0f;

        //isNeedleInDisc = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hapticTargetBools[0] = isNeedleInSkin;
        hapticTargetBools[1] = isNeedleInMuscle;
        hapticTargetBools[2] = isNeedleInDisc;
        hapticTargetBools[3] = isNeedleInStem;

        needleTipHIPPosition = needleTipHIP.transform.position;

        //Get the unit vector between HIP and needle center along the axis
        needleCenterToHIP = needleTipHIPPosition - needle.transform.position;
        cylinderAxis = needleCenterToHIP / Vector3.Magnitude(needleCenterToHIP);
        cylinderAxisIsUnit = Vector3.Magnitude(cylinderAxis);

        //Draw NeedleCenterToHIPLine
        Debug.DrawLine(needle.transform.position, needleTipHIPPosition, Color.cyan);

        totalDorsalCommand = GameObject.Find("SkinMuscleGO").GetComponent<GodObjectController>().dorsalCommand +
            GameObject.Find("DiscGO").GetComponent<GodObjectController>().dorsalCommand +
            GameObject.Find("StemGO").GetComponent<GodObjectController>().dorsalCommand;
        totalVentralCommand = GameObject.Find("SkinMuscleGO").GetComponent<GodObjectController>().ventralCommand +
            GameObject.Find("DiscGO").GetComponent<GodObjectController>().ventralCommand + 
            GameObject.Find("StemGO").GetComponent<GodObjectController>().ventralCommand;

        //Set max limits
        if (totalDorsalCommand > 20.0f)
        {
            totalDorsalCommand = 20.0f;
        }
        if (totalVentralCommand > 20.0f)
        {
            totalVentralCommand = 20.0f;
        }

    }

    //When the needle tip collides with the disc, freeze the z-position of the tipGO
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject == hapticTargets[0])
        {
            //Combine skin and muscle feedback but use muscle mesh collider
            isNeedleInSkin = true;
            isNeedleInMuscle= true;
            Debug.Log("Skin/Muscle  ENTER");
        }
        if (other.gameObject == hapticTargets[2])
        {
            isNeedleInDisc = true;
            Debug.Log(other.gameObject.tag + "  ENTER  OUCH  D': ");
        }
        if (other.gameObject.CompareTag(hapticTargets[3].tag))
        {
            isNeedleInStem = true;
            Debug.Log(other.gameObject.tag + "  ENTER   YAY!!!!!");
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject == hapticTargets[0])
        {
            //Combine skin and muscle feedback but use muscle mesh collider
            isNeedleInSkin = true;
            isNeedleInMuscle = true;
            Debug.Log(other.gameObject.tag + "  EXIT");
        }
        if (other.gameObject == hapticTargets[2])
        {
            isNeedleInDisc = false;
            Debug.Log(other.gameObject.tag + "  EXIT");
        }
        if (other.gameObject.CompareTag(hapticTargets[3].tag))
        {
            isNeedleInStem = false;
            Debug.Log(other.gameObject.tag + "  EXIT");
        }
    }

}
