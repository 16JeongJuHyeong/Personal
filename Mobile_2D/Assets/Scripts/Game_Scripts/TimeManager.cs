using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static int time_flow;
    private float bonus_time_left;

    void Awake()
    {
        time_flow = 1;
        bonus_time_left = 7f;
    }

    void Update()
    {
        if(Spawner.IsBonus && !Pause.IsPause)
        {
            bonus_time_left -= Time.deltaTime;
            if (bonus_time_left < 0f)
            {
                Spawner.IsBonus = false;
                time_flow = 1;
            }
        }
    }

}