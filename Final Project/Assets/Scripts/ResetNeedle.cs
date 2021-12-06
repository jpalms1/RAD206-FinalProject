using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetNeedle : MonoBehaviour
{
    Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    public void resetVirtualTool()
    {
        transform.position = originalPosition;
        transform.eulerAngles = Vector3.zero;
    }
}
