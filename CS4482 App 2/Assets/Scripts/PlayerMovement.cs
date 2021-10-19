using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public float movementSpeed = 10f;       //speed of player movement
    Vector3 movement;                       //vector to store direction for player movement
    Animator anim;                          //reference to animator component5t y 
    Rigidbody playerRigidbody;              //reference to player's rigidbody

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }


}
