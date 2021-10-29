using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    GameObject player;          //reference to player
    public GameObject icon;     //reference to the UI icon of the key

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the entering collider is the player
        if (other.gameObject == player)
        {
            if (this.gameObject.tag == "RustKey")
            {
                CompleteMaze.rustKey = true;
            }
            if (this.gameObject.tag == "SilverKey")
            {
                CompleteMaze.silverKey = true;
            }
            if (this.gameObject.tag == "GoldKey")
            {
                CompleteMaze.goldKey = true;
            }
            this.gameObject.SetActive(false);
            icon.gameObject.SetActive(true);
        }
    }
}
