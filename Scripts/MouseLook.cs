using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // adjust the sensitivity of the mouse
    public float mouseSensitivity = 400f;

    // reference to body of the player:
    public Transform playerBody;

    // rotating the camera view around the x-axis:
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // locking the mouse initially!
        // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // save movement of the mouse for camera view rotation (+ adaptation to framerate)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // - is necessary, bc otherweise, rotation is flipped
        xRotation -= mouseY;

        // clamping the rotation to avoid flipping
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // implementing the rotation:
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
