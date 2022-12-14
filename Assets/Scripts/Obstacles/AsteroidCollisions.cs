using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //asteroid hits character
        if(collision.gameObject.tag == "Character")
        {
            // end the game and show end scene
            StartCountdown.playGame = false;
            CharacterMove.move = false;
            Score.addToScore = false;
            PowerUpTrigger.isPowerupActivated = false;
            SceneManager.LoadScene("EndScreen");
        }

        // asteroid hits obstacle
        if(collision.gameObject.tag == "Obstacle")
        {
            // remove obstacle and destroy asteroid
            collision.gameObject.SetActive(false);
            Destroy(this.gameObject);
            
        }

        // asteroid hits ground
        if(collision.gameObject.tag == "Ground")
        {
            StartCoroutine(DestroyAsteriod(this.gameObject));
        }
    }

    // destroy asteroid
    IEnumerator DestroyAsteriod(GameObject asteriod)
    {
        // destroy asteroid after 15 seconds if not already destroyed
        yield return new WaitForSeconds(15);
        if(asteriod.GetComponent<Collider>() != null)
        {
            Destroy(asteriod);
        }
        
    }
}
