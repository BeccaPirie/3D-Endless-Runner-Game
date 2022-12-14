using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public int speed = 1;
    public AudioSource coinAudio;
    void Update()
    {
        // rotate coin
        transform.Rotate(0, speed, 0, Space.World);
    }

    void OnTriggerEnter(Collider col)
    {
        // if player enters trigger
        if (col.gameObject.tag == "Character")
        {
            // play audio
            coinAudio.Play();
            // add to coin count
            CoinCountController.count += 1;
            // update count in state manager
            MainManager.instance.CoinCount = CoinCountController.count;
            // remove coin
            this.gameObject.SetActive(false);
        }
    }
}
