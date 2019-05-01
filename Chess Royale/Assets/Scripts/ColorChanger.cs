using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Material transparentYellow;
    public Material transparentBlue;
    public Material transparentGreen;
    public Material transparentRed;

    enum color {yellow, blue, green, red};
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
            case color.blue:
                return "Blue";
            case color.green:
                return "Green";
            case color.red:
                return "Red";
            default:
                Debug.Log("Color Not Found");
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
    public void SetToRed()
    {
        if (currentColor != color.red)
        {
            meshRenderer.material.SetColor("_Color", transparentRed.color);
            currentColor = color.red;
        }
    }

}
