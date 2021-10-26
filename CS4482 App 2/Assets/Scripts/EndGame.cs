using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    GameObject player;                          //reference to player
    public static bool complete = false;        //if the player has reached the end

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (complete)
        {
            Debug.Log("Finished!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the entering collider is the player
        if (other.gameObject == player)
        {
            //the player has finished the game
            complete = true;
        }
    }
}
