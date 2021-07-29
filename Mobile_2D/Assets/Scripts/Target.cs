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
                transform.position = transform.position + new Vector3(x_direction, y_direction, 0) * 0.002f * TimeManager.time_flow;
            //transform.position = transform.position + new Vector3(x_direction, y_direction, 0) * 0.002f * Time.timeScale;  //timeScale은 모두 공유
            else
                Destroy(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
}