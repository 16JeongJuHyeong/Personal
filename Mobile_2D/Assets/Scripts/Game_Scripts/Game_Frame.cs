using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Frame : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 60;
    }
}