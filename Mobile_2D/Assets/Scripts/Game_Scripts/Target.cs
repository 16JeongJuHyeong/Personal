using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private SpriteRenderer target_body;

    float x_direction;
    float y_direction;

    void Start()
    {
        target_body = this.gameObject.GetComponent<SpriteRenderer>(); // 프리팹 상태에선 하이라키에 있는 객체들 못 끌어옴
        x_direction = Random.Range(-1.5f, 1.5f);
        y_direction = Random.Range(-1.5f, 1.5f);
    }
    void Update()
    {
        if (Time_Left.game_time > 0)
        {
            if (target_body.isVisible)
                transform.position = transform.position + new Vector3(x_direction, y_direction, 0).normalized * Mathf.Clamp((30 / (Time_Left.game_time + 1)), 0.5f, 3f) * 0.002f * (!Pause.IsPause ? 1 : 0) * TimeManager.time_flow;
            //Mathf.Clamp(float num,float min, float max)
            //Clamp:조임틀에서 유래. 물체가 움직이지 않게 고정시키는 도구 , num:변수
            //정지면 움직이지 않기-정지 아니면 움직이기
            else
                Destroy(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
}