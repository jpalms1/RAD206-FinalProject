using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBody : MonoBehaviour
{
    Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    public void resetBody()
    {
        transform.position = originalPosition;
        transform.eulerAngles = new Vector3(-90.0f, 180.0f, 180.0f);
    }
}
