using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Bonus_byClass : Target_byClass 
{
    protected override void OnMouseDown()
    {
        if (!Pause.IsPause)
        {
            Destroy(this.gameObject);
            score.score += 10;
        }
    }
    void Update() 
    {
        if (Time_Left.game_time > 0)
        {
            if (target_body.isVisible)
                transform.position = transform.position + new Vector3(x_direction, y_direction, 0).normalized  * 0.01f * (!Pause.IsPause ? 1 : 0);
            else
                Destroy(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
}