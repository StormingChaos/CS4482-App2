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
            
            //transform.Rotate(0, rotationSpeed, 0, Space.Self);
        }
        else if (h < 0)
        {
            Quaternion newRotation = Quaternion.Euler(velocityLeft * Time.fixedDeltaTime);
            playerRigidbody.MoveRotation(playerRigidbody.rotation * newRotation);

            //transform.Rotate(0, -rotationSpeed, 0, Space.Self);
        }
    }

    //void Turning()
    //{
    //    // Create a ray from the player position to 
    //    Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    // Perform the raycast and if it hits something on the floor layer...
    //    if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
    //    {
    //        // Create a vector from the player to the point on the floor the raycast from the mouse hit.
    //        Vector3 playerToMouse = floorHit.point - transform.position;
    //        // Ensure the vector is entirely along the floor plane.
    //        playerToMouse.y = 0f;

    //        // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
    //        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
    //        // Set the player's rotation to this new rotation.
    //        playerRigidbody.MoveRotation(newRotation);
    //    }
    //}

    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;
        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
    }
}
