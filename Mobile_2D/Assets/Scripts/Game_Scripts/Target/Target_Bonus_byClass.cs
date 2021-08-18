using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Bonus_byClass : Target_byClass 
{
    void Start()
    {
        Moving_Speed = 0.01f;
    }
    protected override void OnMouseDown()
    {
        if (!Pause.IsPause)
        {
            Destroy(this.gameObject);
            score.score += 5;
        }
    }

    protected override void Moving()
    {
        if (Time_Left.game_time > 0)
        {
            if (target_body.isVisible)
                transform.position = transform.position + ( Moving_Direction * Moving_Speed * Bonus_Stop);
            else
                Destroy(this.gameObject);
        }
    }
}