using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Material transparentYellow;
    public Material transparentBlue;

    private bool blue;
    MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetToBlue()
    {
        meshRenderer.material.SetColor("_Color", transparentBlue.color);
    }

    public void SetToYellow()
    {
        meshRenderer.material.SetColor("_Color", transparentYellow.color);
    }
}
