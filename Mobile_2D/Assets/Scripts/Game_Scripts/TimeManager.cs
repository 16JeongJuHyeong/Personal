using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static bool time_flow;

    [SerializeField] private AudioSource Background_Music;

    private float bonus_time_left;

    void Start()
    {
        time_flow = true;
        bonus_time_left = 7f;
    }

    void Update()
    {
        Bonus_Timer();
    }

    void Bonus_Timer()
    {
        if (Spawner.IsBonus && !Pause.IsPause)
        {
            bonus_time_left -= Time.deltaTime;
            if (bonus_time_left < 0f)
            {
                Background_Music.Play();
                Spawner.IsBonus = false;
                time_flow = true;
            }
        }
    }
}