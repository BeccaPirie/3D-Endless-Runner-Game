using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleScript : MonoBehaviour
{
    public GameObject theCharacter;
    public GameObject controller;
    void OnTriggerEnter(Collider col)
    {
        // end the game if the player collides with an obstacle
        if (col.gameObject.tag == "Character")
        {
            StartCountdown.playGame = false;
            CharacterMove.move = false;
            Score.addToScore = false;
            PowerUpTrigger.isPowerupActivated = false;
            Asteroids.isAsteriodFalling = false;
            SceneManager.LoadScene("EndScreen");
        }
    }
}
