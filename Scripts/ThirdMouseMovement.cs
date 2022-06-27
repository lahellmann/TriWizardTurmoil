using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @param Time.delteTime < 0 ->  when mouse left, object turns right
 **/
public class ThirdMouseMovement : MonoBehaviour
{
    /**
     * Moving in Thirdperson view. This is a script to turn a given Object (%param Transform) towards the mouse, 
     * so the Cinematiccamera can follow undisturbed.
     **/

    public Transform body;
    //public Transform head;
    public float rotationSpeed = 12f;
    float headAngleX;
    float headAngleY;

    void Start()
    {
        headAngleX = 180;
        body.localRotation = Quaternion.AngleAxis(headAngleX, Vector3.up);
        //head.localRotation = Quaternion.AngleAxis(headAngleX, Vector3.up);
        //headAngleY = 0;
        //head.localRotation = Quaternion.AngleAxis(headAngleY, Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        float time = -Time.deltaTime;
        rotateBody(time);
        //rotateY(time);
        //rotateHead(time);

    }

    void rotateBody(float time)
    {
        headAngleX += Input.GetAxis("Mouse X") * rotationSpeed * time;
        //headAngleX = Mathf.Clamp(headAngleX,0,360);
        body.localRotation = Quaternion.AngleAxis(headAngleX, Vector3.up); //rotate only on Y -> left/right, not up/down
    }

    /*void rotateY(float time)
    {
        headAngleY += Input.GetAxis("Mouse Y") * rotationSpeed * time;
        headAngleY = Mathf.Clamp(headAngleY, 80,-10);
        body.localRotation = Quaternion.AngleAxis(headAngleY, Vector3.right); //rotate only on x ->  up/down
    }
    void rotateHead(float time)
    {

        headAngleX += Input.GetAxis("Mouse X") * rotationSpeed * time;
        headAngleY += Input.GetAxis("Mouse Y") * rotationSpeed * time;
        //headAngleY = Mathf.Clamp(headAngleY, 80, -10);
        head.localRotation = Quaternion.Euler(headAngleY, headAngleX, 0); //rotate only on x ->  up/down
    }*/
}
