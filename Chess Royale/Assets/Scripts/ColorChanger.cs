using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Material transparentYellow;
    public Material transparentBlue;
    public Material transparentGreen;

    enum color {yellow, blue, green };
    color currentColor;

    MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        currentColor = color.blue;
        SetToBlue();
    }

    public string GetColor()
    {
        switch(currentColor)
        {
            case color.yellow:
                return "Yellow";
                break;
            case color.blue:
                return "Blue";
                break;
            case color.green:
                return "Green";
                break;
            default:
                return "null";
        }
    }

    public void SetToBlue()
    {
        if (currentColor != color.blue)
        {
            meshRenderer.material.SetColor("_Color", transparentBlue.color);
            currentColor = color.blue;
        }
    }

    public void SetToYellow()
    {
        if (currentColor != color.yellow)
        {
            meshRenderer.material.SetColor("_Color", transparentYellow.color);
            currentColor = color.yellow;
        }
    }

    public void SetToGreen()
    {
        if (currentColor != color.green)
        {
            meshRenderer.material.SetColor("_Color", transparentGreen.color);
            currentColor = color.green;
        }
    }

}
