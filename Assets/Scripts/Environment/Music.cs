using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    void Start()
    {
        // play background music continuously between scenes
        DontDestroyOnLoad(this);
    }
}
