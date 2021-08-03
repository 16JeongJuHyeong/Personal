using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private SpriteRenderer target_body;

    float x_direction;
    float y_direction;

    void Start()
    {
        target_body = this.gameObject.GetComponent<SpriteRenderer>();  // 프리팹 상태에선 하이라키에 있는 객체들 못 끌어옴
        x_direction = Random.Range(-1.5f, 1.5f);
        y_direction = Random.Range(-1.5f, 1.5f);
    }

    void Update()
    {
        if (target_body.isVisible)
            transform.position = transform.position + new Vector3(x_direction, y_direction, 0).normalized * 0.004f * (!Pause.IsPause ? 1:0);
        // 일시정지 됐을 때 보너스가 안 움직이게 설정
        else
            Destroy(this.gameObject);
    }
}