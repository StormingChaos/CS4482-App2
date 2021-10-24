using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //reference variables
    public GameObject player;
    public float camDistance = 3f;
    public float camHeight = 1f;

    //update runs every frame
    private void LateUpdate()
    {
        transform.position = player.transform.position - player.transform.forward * camDistance;
        transform.LookAt(player.transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y + camHeight, transform.position.z);
    }
}
