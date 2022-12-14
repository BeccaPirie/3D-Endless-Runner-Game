using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpTrigger : MonoBehaviour
{
    public Renderer powerupRenderer;
    public GameObject powerupText;
    public static bool isPowerupActivated = false;  

    void OnTriggerEnter(Collider col)
    {
        // activate powerup when player collides with object
        if(col.gameObject.tag == "Character")
        {
            if (!isPowerupActivated)
            {
                isPowerupActivated = true;
                StartCoroutine(ActivatePowerup());
            }
            powerupRenderer.enabled = false;
        }
        
    }

    // allow player to use powerup for set amount of time
    IEnumerator ActivatePowerup()
    {
        powerupText.SetActive(true);
        yield return new WaitForSeconds(5);
        isPowerupActivated = false;
        powerupRenderer.enabled = true;
        powerupText.SetActive(false);
    }
}
