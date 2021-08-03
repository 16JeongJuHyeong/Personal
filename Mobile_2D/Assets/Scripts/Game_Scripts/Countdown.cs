using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField]
    private GameObject Pause_Button;

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
            count_check();
    }

    void count_check()
    {
        anim_time -= Time.deltaTime;
        if (anim_time < 0)
        {
            Pause.IsPause = false;
            count_ready = false;
            this.gameObject.SetActive(false);
            anim_time = 3f;
            Pause_Button.GetComponent<Button>().interactable = true;
            if (!Spawner.IsBonus)
                TimeManager.time_flow = 1;
        }
    }
}