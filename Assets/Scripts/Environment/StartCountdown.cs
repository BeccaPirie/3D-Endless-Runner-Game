using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCountdown : MonoBehaviour
{
    public GameObject three;
    public GameObject two;
    public GameObject one;
    public GameObject go;
    public AudioSource countdownAudio;
    public AudioSource goAudio;
    static public bool playGame = false;

    void Start()
    {
        StartCoroutine(Countdown());
    }

    // game countdown
    IEnumerator Countdown()
    {
        // show countdown number and play audio every second of countdown
        yield return new WaitForSeconds(1);
        three.SetActive(true);
        countdownAudio.Play();
        yield return new WaitForSeconds(1);
        two.SetActive(true);
        countdownAudio.Play();
        yield return new WaitForSeconds(1);
        one.SetActive(true);
        countdownAudio.Play();
        yield return new WaitForSeconds(1);
        go.SetActive(true);
        goAudio.Play();
        // start game at the end of countdown
        CharacterMove.move = true;
        playGame = true;
    }
}
