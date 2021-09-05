using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Hostile_byClass : Target_byClass
{
    public Spawner Hostile_Spawn;
    private float Hostile_Control;
    void Start()
    {
        Hostile_Spawn = GameObject.Find("Spawner").GetComponent<Spawner>();
        Moving_Speed = 0.005f;
    }

    protected override void OnMouseDown()
    {
        if(Time.timeScale > 0f && TimeManager.time_flow)
        {
            Hostile_Spawn.Hostile_Is_In_Game = false;
            Destroy(this.gameObject);
            Score.score -= 30;
        }
    }

    protected override void Moving()
    {
        Hostile_Control = (TimeManager.time_flow ? 1f : 0) * (Time.timeScale > 0f ? 1f : 0);
        if (target_body.isVisible)
        {
            transform.position = transform.position + (Moving_Direction * Moving_Speed * Hostile_Control);
            transform.Rotate(0, 0, Rotate_speed * Hostile_Control);
            //*Rotate(x,y,z) 각 좌표계에 x,y,z만큼 더함
        }
        else
        {
            Hostile_Spawn.Hostile_Is_In_Game = false;
            Destroy(this.gameObject);
        }
    }
}