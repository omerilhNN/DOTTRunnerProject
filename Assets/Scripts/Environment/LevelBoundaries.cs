using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundaries : MonoBehaviour
{
    public static float leftSide = -8f;
    public static float rightSide=6f;
    public float internalLeft;
    public float internalRight;
    void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;

       
    }
}
