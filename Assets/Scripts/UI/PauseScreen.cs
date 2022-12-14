using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public int score;
    public int coins;
    public GameObject pauseScreen;
    public GameObject scoreDisplay;
    public GameObject coinDisplay;
    public GameObject scoreText;
    public GameObject coinText;
    public GameObject pauseBtn;

    public AudioSource countdownAudio;
    public AudioSource goAudio;
    public AudioSource btnPress;

    private void Update()
    {
        // use escape key to pause and resume game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!StartCountdown.playGame && !CharacterMove.run)
            {
                btnPress.Play();
                ResumeGame();
            }
            else if(StartCountdown.playGame)
            {
                btnPress.Play();
                PauseGame();
            }
        }
    }

    // pause the game
    public void PauseGame()
    {
        if (StartCountdown.playGame)
        {
            scoreDisplay.SetActive(false);
            coinDisplay.SetActive(false);
            pauseBtn.SetActive(false);
            pauseScreen.SetActive(true);
            Score.addToScore = false;
            CharacterMove.run = false;
            CharacterMove.move = false;
            StartCountdown.playGame = false;
            Asteroids.isAsteriodFalling = false;

            if (MainManager.instance != null)
            {
                score = MainManager.instance.Score;
                coins = MainManager.instance.CoinCount;
                scoreText.GetComponent<Text>().text = score.ToString();
                coinText.GetComponent<Text>().text = coins.ToString();
            }
        }
    }

    // resume the game
    public void ResumeGame()
    {
        scoreDisplay.SetActive(true);
        coinDisplay.SetActive(true);
        pauseBtn.SetActive(true);
        pauseScreen.SetActive(false);
        StartCoroutine(ResumeCountdown());
    }

    // countdown before game resumes again
    IEnumerator ResumeCountdown()
    {
        yield return new WaitForSeconds(0.3f);
        countdownAudio.Play();
        yield return new WaitForSeconds(1);
        countdownAudio.Play();
        yield return new WaitForSeconds(1);
        countdownAudio.Play();
        yield return new WaitForSeconds(1);
        goAudio.Play();
        CharacterMove.run = true;
        CharacterMove.move = true;
        StartCountdown.playGame = true;
    }

    // load home screen
    public void BackToHome()
    {
        scoreDisplay.SetActive(true);
        coinDisplay.SetActive(true);
        pauseBtn.SetActive(true);
        pauseScreen.SetActive(false);
        CharacterMove.run = true;
        CharacterMove.move = false;
        Score.score = 0;
        CoinCountController.count = 0;
        PowerUpTrigger.isPowerupActivated = false;
        MainManager.instance.Score = 0;
        MainManager.instance.CoinCount = 0;
        SceneManager.LoadScene("StartScreen");
    }

    // exit the game
    public void Quit()
    {
        Application.Quit();
    }
}
