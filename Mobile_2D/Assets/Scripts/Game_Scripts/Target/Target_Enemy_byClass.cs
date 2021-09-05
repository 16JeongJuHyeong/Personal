using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Enemy_byClass : Target_byClass //Target_byClass 상속. 속성들 및 Start함수 물려받음
{
    private float Targets_Control;
    private float Moving_Regulator;
    void Start()
    {
        Moving_Speed = 0.05f;
    }

    protected override void OnMouseDown()
    {
        if (Time.timeScale > 0f && TimeManager.time_flow)
        {
            Destroy(this.gameObject);
            Score.score += 10;
        }
    }

    protected override void Moving()
    {
        Targets_Control = (TimeManager.time_flow ? 1f : 0) * (Time.timeScale > 0f ? 1f : 0);  //Targets_Stop = (TimeManager.IsPause ? 0 : 1) * (TimeManager.time_flow ? 1 : 0);
        Moving_Regulator = Mathf.Clamp((30 / (TimeManager.game_time + 1)), 0.5f, 3f); // (변수 , 최소값 , 최대값) 특정 변수의 범위를 제한함
        if (target_body.isVisible) 
        {
            transform.position = transform.position + ( Moving_Direction * Moving_Regulator * Moving_Speed * Targets_Control); //*상수화 시켜 가독성 증가 , 유지보수 용이
            transform.Rotate( 0, 0, Rotate_speed * (TimeManager.time_flow ? 1 : 0) );
        }
        else
            Destroy(this.gameObject);
    }
}