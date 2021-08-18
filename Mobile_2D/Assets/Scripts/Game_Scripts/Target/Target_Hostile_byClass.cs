using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Hostile_byClass : Target_byClass
{
    public Spawner Hostile_Spawn;
    void Start()
    {
        Hostile_Spawn = GameObject.Find("Spawner").GetComponent<Spawner>();
        Hostile_Spawn.Hostile_Is_In_Game = true;
        Moving_Speed = 0.001f;
    }

    protected override void OnMouseDown()
    {
        if (!Spawner.IsBonus && !Pause.IsPause)
        {
            Hostile_Spawn.Hostile_Is_In_Game = false;
            Destroy(this.gameObject);
            score.score -= 30;
        }
    }

    protected override void Moving()
    {
        if (target_body.isVisible)
        {
            transform.position = transform.position + (Moving_Direction * Moving_Speed * Targets_Stop);
            transform.Rotate(0, 0, Rotate_speed * (!Pause.IsPause ? 1 : 0) * (TimeManager.time_flow ? 1 : 0));

            //*Rotate(x,y,z) 각 좌표계에 x,y,z만큼 더함
            //*transform.rotation = transform.rotation + Quaternion.Euler(0,0,Time.deltaTime * (!Pause.IsPause ? 1 : 0) * TimeManager.time_flow); 는 안됨
        }
        else
        {
            Hostile_Spawn.Hostile_Is_In_Game = false;
            Destroy(this.gameObject);
        }
    }
}