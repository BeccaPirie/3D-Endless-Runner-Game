using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObstacle : MonoBehaviour
{
    public Rigidbody obstacleRb;
    public float floatingPosition = 0.9f;

    void FixedUpdate()
    {
        if (transform.position.y < floatingPosition)
        {
            // apply force upwards
            obstacleRb.AddForce(Vector3.up * 17f);
        }

        if (transform.position.y >= floatingPosition)
        {
            // apply force that is less than gravitational force
            obstacleRb.AddForce(Vector3.up * 11f);
        }
    }
}
