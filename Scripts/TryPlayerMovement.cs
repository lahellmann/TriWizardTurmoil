using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryPlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 12f;

    // Update is called once per frame
    void Update()
    {
        while (!controller.isGrounded)
        {
            transform.Translate(0f, -1f, 0f);
            Debug.Log("Ground_Collision");
        }

        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

    }
}
