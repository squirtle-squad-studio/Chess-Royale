using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private bool isBlackTurn;
    [Header("Camera Starting Positions")]
    public Transform blackStartPosition;
    public Transform blackEndPosition;
    public Transform rotatingPoint;

    [Header("Camera travel time")]
    public float speed;
    public float journeyTime;

    private float activationTime;
    private float startTime;
    private Vector3 startRel;
    private Vector3 endRel;
    private Vector3 midPoint;

    // Start is called before the first frame update
    void Start()
    {
        isBlackTurn = false;
        activationTime = -journeyTime * speed - 1; // So that the game runs, it doesn't trigger the cam move
        transform.position = blackEndPosition.position; // White's cam view
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - activationTime > journeyTime*speed) // Necessary to not call in the beginning of the game
        {
            return;
        }
        if(isBlackTurn)
        {
            UpdateCenter(Vector3.right);
        }
        else
        {
            UpdateCenter(Vector3.left);
        }
        float fracComplete = (Time.time - startTime) / journeyTime; // The percent completed based on time since the first call
        transform.position = Vector3.Slerp(startRel, endRel, fracComplete * speed);
        transform.position += midPoint;
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(rotatingPoint.position - transform.position, Vector3.up); // Locks the camera to look at the direction of the rotatingPoint
                                                                                                               // While also focus on keeping the Y-axis facing up
    }

    public void NextPlayerCam()
    {
        isBlackTurn = !isBlackTurn;
        activationTime = Time.time;
        startTime = Time.time;

        Vector3 temp = blackStartPosition.position;
        blackStartPosition.position = blackEndPosition.position;
        blackEndPosition.position = temp;
    }

    /*
     * Used to prepare for Vector3.Slerp(start - mid, end - mid, fractionOfCompletion)
     */
    public void UpdateCenter(Vector3 direction)
    {
        midPoint = (blackStartPosition.position + blackEndPosition.position) * 0.5f;
        midPoint -= direction;
        startRel = blackStartPosition.position - midPoint;
        endRel = blackEndPosition.position - midPoint;

    }
}
