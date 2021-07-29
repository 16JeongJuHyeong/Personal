﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Left : MonoBehaviour
{

    [SerializeField]
    private Text time;

    public static float game_time;

    void Start()
    {
        game_time = 60f;
    }

    void Update()
    {
        if(Spawner.spawn)
        {
            game_time -= Time.deltaTime;
            time.text = "Time: " + game_time.ToString("N0") + "sec";
        }
    }
}