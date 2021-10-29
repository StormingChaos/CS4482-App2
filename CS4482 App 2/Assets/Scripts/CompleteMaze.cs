using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteMaze : MonoBehaviour
{
    GameObject player;                          //reference to player
    public static bool victory = false;         //if the player has reached the end
    public static bool rustKey = false;         //if the player has picked up the rust key
    public static bool silverKey = false;       //if the player has picked up the silver key
    public static bool goldKey = false;         //if the player has picked up the gold key

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (victory)
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
            victory = true;
        }
    }
}
