using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    private float anim_time;

    void count_check()
    {
        anim_time -= Time.deltaTime;
        if (anim_time < 0)
        {
            Spawner.spawn = true;
            this.gameObject.SetActive(false);
        }

    }

    void Start()
    {
        anim_time = 3f;
    }

    void Update()
    {
        count_check();
    }

}
