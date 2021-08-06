using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Enemy_byClass : Target_byClass //Target_byClass 상속. 속성들 및 Start함수 물려받음
{
    void Update() //*Update()도 이벤트 함수. Update Start 등은 On 생략 가능
    {
        if (Time_Left.game_time > 0)
        {
            if (target_body.isVisible) // 에너미 객체. 시간에 따라 속도 증가
                transform.position = transform.position + new Vector3(x_direction, y_direction, 0).normalized * Mathf.Clamp((30 / (Time_Left.game_time + 1)), 0.5f, 3f) * 0.01f * (!Pause.IsPause ? 1 : 0) * TimeManager.time_flow;
            else
                Destroy(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
}