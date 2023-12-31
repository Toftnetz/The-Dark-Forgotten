using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float running = 100f;
    public float gravity = -9.82f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public AudioSource footstepsSound;

    Vector3 velocity;
    bool isGrounded;

    public static int keyCount;
    public static int GasCan;
    public static int Fuse;
    public static int Electricity;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded&& velocity.y <0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right*x+transform.forward*z;
        controller.Move(move*speed*Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            footstepsSound.enabled = true;
        }
        else
        {
            footstepsSound.enabled = false;
        }

        if (Input.GetKey("left shift"))
        {
            controller.Move(move * running * Time.deltaTime);
        }

        
    }
}
