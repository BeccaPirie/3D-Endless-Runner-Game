using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCountController : MonoBehaviour
{
    public static int count;
    public GameObject coinDisplay;

    
    void Update()
    {
        // set the coin display
        coinDisplay.GetComponent<Text>().text = count.ToString();
    }
}
