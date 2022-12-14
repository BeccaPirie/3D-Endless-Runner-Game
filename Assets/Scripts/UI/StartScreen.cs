using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public GameObject highScoreDisplay;
    public string highScore;

    public void Start()
    {
        // get and display highscore from PlayerPrefs
        if (PlayerPrefs.HasKey("highscore"))
        {
            highScore = PlayerPrefs.GetString("highscore").ToString();
            highScoreDisplay.GetComponent<Text>().text = highScore;
        }
    }

    // load level player selects
    public void ChangeScene(string name)
    {
        MainManager.instance.selectedOption = name;
        SceneManager.LoadScene(name);   
    }

    // exit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
