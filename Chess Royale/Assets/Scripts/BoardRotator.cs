using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardRotator : MonoBehaviour
{
    public GameObject whitePieces;
    public GameObject BlackPieces;

    private bool isNormalRotation;

    public void Start()
    {
        isNormalRotation = true;
    }

    public void Rotate()
    {
        if(isNormalRotation)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            whitePieces.transform.rotation = Quaternion.Euler(0, 180, 0);
            BlackPieces.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            whitePieces.transform.rotation = Quaternion.Euler(0, 0, 0);
            BlackPieces.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        isNormalRotation = !isNormalRotation;
    }
}
