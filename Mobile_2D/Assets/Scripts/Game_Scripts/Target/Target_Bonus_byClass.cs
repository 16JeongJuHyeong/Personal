using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Bonus_byClass : Target_byClass 
{
    protected float Bonus_Control;
    void Start()
    {
        Moving_Speed = 0.05f;
    }
    protected override void OnMouseDown()
    {
        if(Time.timeScale > 0f)
        {
            Destroy(this.gameObject);
            Score.score += 5;
        }
    }

    protected override void Moving()
    {
        Bonus_Control = (Time.timeScale > 0f ? 1f : 0);
        if (TimeManager.game_time > 0)
        {
            if (target_body.isVisible)
                transform.position = transform.position + (Moving_Direction * Moving_Speed * Bonus_Control);
            else
                Destroy(this.gameObject);

        }
    }
}