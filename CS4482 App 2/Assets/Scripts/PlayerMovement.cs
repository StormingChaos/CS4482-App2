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

        //dont let the player move if they are inputing text
        if (!VictoryManager.getInput)
        {
            // Move the player around the scene and Animate the player.
            Animating(Move(h, v));
        }
    }

    bool Move(float h, float v)
    {
        bool IsMoving = false;

        if (v > 0f)
        {
            playerRigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime * movementSpeed);
            IsMoving = true;
        }
        else if (v < 0f)
        {
            playerRigidbody.MovePosition(transform.position - transform.forward * Time.deltaTime * movementSpeed);
            IsMoving = true;
        }
        else
        {
            playerRigidbody.MovePosition(transform.position);
        }

        if (h > 0f)
        {
            Quaternion newRotation = Quaternion.Euler(velocityRight*Time.fixedDeltaTime);
            playerRigidbody.MoveRotation(playerRigidbody.rotation*newRotation);
            IsMoving = true;
        }
        else if (h < 0f)
        {
            Quaternion newRotation = Quaternion.Euler(velocityLeft * Time.fixedDeltaTime);
            playerRigidbody.MoveRotation(playerRigidbody.rotation * newRotation);
            IsMoving = true;
        }
        else
        {
            playerRigidbody.MoveRotation(playerRigidbody.rotation);
        }

        return IsMoving;
    }

    void Animating(bool isMoving)
    {
        // If either of the input axes is non-zero, & tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", isMoving);
    }
}
