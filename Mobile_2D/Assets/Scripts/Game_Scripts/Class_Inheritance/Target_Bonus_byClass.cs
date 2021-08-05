using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Bonus_byClass : Target_byClass 
{
    void Update() 
    {
        if (Time_Left.game_time > 0)
        {
            if (target_body.isVisible) // 보너스 객체. 시간에 따라 속도 증가 없고 전반적으로 빠름
                transform.position = transform.position + new Vector3(x_direction, y_direction, 0).normalized  * 0.02f * (!Pause.IsPause ? 1 : 0);
            else
                Destroy(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
}