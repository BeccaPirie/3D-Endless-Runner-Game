using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupFloat : MonoBehaviour
{
    public Rigidbody powerupRb;
    public float floatingPosition = 1.3f;

    void FixedUpdate()
    {
        if (transform.position.y < floatingPosition)
        {
            // apply force upwards
            powerupRb.AddForce(Vector3.up * 17f);
        }

        if (transform.position.y >= floatingPosition)
        {
            // apply force that is less than gravitational force
            powerupRb.AddForce(Vector3.up * 11f);
        }
    }
}
