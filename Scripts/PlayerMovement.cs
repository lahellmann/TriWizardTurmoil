using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float moveSpeed = 12f;
    
    // no start method necessary :)

    void Update()
    {
        // create some input first:
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // movement in the way we are currently looking:
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        // the mover unmoved xD:
        controller.Move(move * moveSpeed * Time.deltaTime);


    }
}
