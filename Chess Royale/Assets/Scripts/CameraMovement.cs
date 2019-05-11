using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private bool isBlackTurn;

    public Transform blackStartPosition;
    public Transform blackEndPosition;

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
        startTime = journeyTime*speed + 1; // So that camera Doesn' rotate in the beginning
        transform.position = blackEndPosition.position; // White's cam view
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - activationTime > journeyTime*speed + 1)
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
        float fracComplete = (Time.time - startTime) / journeyTime * speed;
        transform.position = Vector3.Slerp(startRel, endRel, fracComplete * speed);
        transform.position += midPoint;

    }

    public void NextPlayerCam()
    {
        isBlackTurn = !isBlackTurn;
        activationTime = Time.time;
        startTime = Time.time;

        // Switch places
        Vector3 temp = blackStartPosition.position;
        blackStartPosition.position = blackEndPosition.position;
        blackEndPosition.position = temp;
    }

    public void UpdateCenter(Vector3 direction)
    {
        midPoint = (blackStartPosition.position + blackEndPosition.position) * 0.5f;
        midPoint -= direction;
        startRel = blackStartPosition.position - midPoint;
        endRel = blackEndPosition.position - midPoint;

    }
}
