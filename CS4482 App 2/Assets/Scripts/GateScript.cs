using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    GameObject player;                  //reference to player
    public float sinkSpeed = 2.5f;      //speed that the door will sin into the floor to open
    public float destroyDelay = 2f;     //delay until the gameobject is destroyed
    bool isOpen = false;                //if the door is open or not

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        //if the door should be open
        if (isOpen)
        {
            //have the door sink into the ground
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (this.gameObject.tag == "RustGate")
            {
                if (CompleteMaze.rustKey)
                {
                    Debug.Log("Opening Rust Gate");
                    Open();
                }
            }
            if (this.gameObject.tag == "SilverGate")
            {
                if (CompleteMaze.silverKey)
                {
                    Debug.Log("Opening Silver Gate");
                    Open();
                }
            }
            if (this.gameObject.tag == "GoldGate")
            {
                if (CompleteMaze.goldKey)
                {
                    Debug.Log("Opening Gold Gate");
                    Open();
                }
            }
        }
    }

    void Open()
    {
        //tell the door to start opening
        isOpen = true;
        // After 2 seconds destroy the enemy.
        Destroy(gameObject, destroyDelay);
    }
}
