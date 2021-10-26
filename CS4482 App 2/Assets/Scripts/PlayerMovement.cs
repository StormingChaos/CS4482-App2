using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;        //speed of player movement
    public float rotationSpeed = 100f;      //how many degrees to rotate per second

    Vector3 velocityRight;                  //vector to store angular velocity of rotation
    Vector3 velocityLeft;
    Animator anim;                          //reference to animator component 
    Rigidbody playerRigidbody;              //reference to player's rigidbody

    private void Awake()
    {
        //get references
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();

        //set angular velocity
        velocityRight = new Vector3(0, rotationSpeed, 0);
        velocityLeft = new Vector3(0, -rotationSpeed, 0);
    }

    private void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Move the player around the scene.
        Move(h, v);
        // Animate the player.
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        if (v > 0)
        {
            playerRigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime * movementSpeed);
        }
        else if (v < 0)
        {
            playerRigidbody.MovePosition(transform.position - transform.forward * Time.deltaTime * movementSpeed);
        }

        if (h > 0)
        {
            Quaternion newRotation = Quaternion.Euler(velocityRight*Time.fixedDeltaTime);
            playerRigidbody.MoveRotation(playerRigidbody.rotation*newRotation);
        }
        else if (h < 0)
        {
            Quaternion newRotation = Quaternion.Euler(velocityLeft * Time.fixedDeltaTime);
            playerRigidbody.MoveRotation(playerRigidbody.rotation * newRotation);
        }
    }

    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;
        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
    }
}
