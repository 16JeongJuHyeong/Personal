using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    private float anim_time;
    public bool count_ready;

    void Start()
    {
        anim_time = 3f;
        count_ready = true;
    }

    void Update()
    {
        if (count_ready)
        {
            count_check();
        }
    }

    void count_check()
    {
        anim_time -= Time.deltaTime;
        if (anim_time < 0)
        {
            count_ready = false;
            Spawner.spawn = true;
            this.gameObject.SetActive(false);
            TimeManager.time_flow = 1;
            anim_time = 3f;
        }
    }
}