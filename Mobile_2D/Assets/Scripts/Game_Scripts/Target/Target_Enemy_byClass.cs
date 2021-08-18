using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Enemy_byClass : Target_byClass //Target_byClass 상속. 속성들 및 Start함수 물려받음
{
    private float Moving_Regulator;
    
    void Start()
    {
        Moving_Speed = 0.01f;
    }
    protected override void OnMouseDown()
    {
        if (!Spawner.IsBonus && !Pause.IsPause && TimeManager.time_flow)
        {
            Destroy(this.gameObject);
            score.score += 10;
        }
    }

    protected override void Moving()
    {
        Moving_Regulator = Mathf.Clamp((30 / (Time_Left.game_time + 1)), 0.5f, 3f);
        if (target_body.isVisible) // 에너미 객체. 시간에 따라 속도 증가
        {
            transform.position = transform.position + ( Moving_Direction * Moving_Regulator * Moving_Speed * Targets_Stop); //*상수들을 const 시켜 가독성 증가 , 유지보수 용이
            transform.Rotate( 0, 0, Rotate_speed * (!Pause.IsPause ? 1 : 0) * (TimeManager.time_flow ? 1 : 0) );
        }
        else
            Destroy(this.gameObject);
    }
}

//Mathf.Clamp(value ,Min , Max)