using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public int score;
    public int coins;
    public GameObject scoreDisplay;
    public GameObject coinDisplay;
    public int highScore;

    private void Start()
    {
        // set score and coin displays
        if (MainManager.instance != null)
        {
            score = MainManager.instance.Score;
            coins = MainManager.instance.CoinCount;
            scoreDisplay.GetComponent<Text>().text = score.ToString();
            coinDisplay.GetComponent<Text>().text = coins.ToString();

            // save score if new highscore
            if(score > highScore)
            {
                PlayerPrefs.SetString("highscore", score.ToString());
                PlayerPrefs.Save();
            }

            // reset counts
            Score.score = 0;
            CoinCountController.count = 0;
            MainManager.instance.Score = 0;
            MainManager.instance.CoinCount = 0;
        }
    }

    // load scene of selected level
    public void PlayAgain()
    {
        SceneManager.LoadScene(MainManager.instance.selectedOption);
    }

    // load home screen
    public void Home()
    {
        SceneManager.LoadScene("StartScreen");
    }

    // exit the application
    public void Exit()
    {
        Application.Quit();
    }
}
