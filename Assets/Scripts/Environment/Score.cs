using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    public GameObject scoreDisplay;
    public static bool addToScore = false;

    void Update()
    {
        // add to score when playing the game
        if (addToScore == false & StartCountdown.playGame == true)
        {
            addToScore = true;
            StartCoroutine(AddToScore());
        }
    }

    // add to score at set intervals
    IEnumerator AddToScore()
    {
        score += 1;
        // update score in game state manager
        MainManager.instance.Score = score;
        // display score
        scoreDisplay.GetComponent<Text>().text = score.ToString();
        yield return new WaitForSeconds(0.3f); ;
        addToScore = false;
    }
}
