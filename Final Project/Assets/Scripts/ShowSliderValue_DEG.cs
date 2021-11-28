//
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos
{
    //[AddComponentMenu("Scripts/MRTK/Examples/ShowSliderValue")]
    public class ShowSliderValue_DEG : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro textMesh = null;

        public void OnSliderUpdated(SliderEventData eventData)
        {
            if (textMesh == null)
            {
                textMesh = GetComponent<TextMeshPro>();
            }

            if (textMesh != null)
            {
                textMesh.text = $"{eventData.NewValue*360.0f:F2}\u00B0";
            }
        }
    }
}
