using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = this.transform.rotation;
        float delta = rotationSpeed * Time.deltaTime;
        rotation *= Quaternion.Euler(0, delta, 0);
        this.transform.rotation = rotation;
    }
}
