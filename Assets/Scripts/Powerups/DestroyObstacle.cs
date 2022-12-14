using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // if projectile collides with an obstacle, remove the obstacle and destroy the projectile
        if (collision.gameObject.tag == "Obstacle" )
        {
            collision.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
