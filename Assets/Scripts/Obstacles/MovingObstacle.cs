using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{   
    public float speed = 2.0f;
    public bool movingRight = true;

    void Update()
    {
        // only move obstacle during gameplay
        if (CharacterMove.run)
        {
            MoveObstacle();
        }
    }
        
    void MoveObstacle()
    {
        // move obstacle left and right
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }

        // set which direction obstacle should move in based on current position
        if (transform.position.x >= 2)
        {
            movingRight = false;
        }
        if (transform.position.x <= -2)
        {
            movingRight = true;
        }
    }
}
