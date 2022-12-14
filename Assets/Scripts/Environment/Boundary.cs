using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public static float leftSide = -3.5f;
    public static float rightSide = 3.5f;
    public float internalLeft;
    public float internalRight;

    void Update()
    {
        // set boundaries so character stays on course
        internalLeft = leftSide;
        internalRight = rightSide;
    }
}
