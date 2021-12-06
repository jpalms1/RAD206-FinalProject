using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowMesh : MonoBehaviour
{
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void hideShow()
    {
        if (meshRenderer.enabled == true)
        {
            meshRenderer.enabled = false;
        }
        else
        {
            meshRenderer.enabled = true;
        }
    }
}