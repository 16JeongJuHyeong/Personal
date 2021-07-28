using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer target_body;
    //public Time_Left time_left;

    float x_direction;
    float y_direction;
    void Start()
    {
        //time_left = GameObject.Find("Time").GetComponent<Time_Left>();//프리팹 상태에선 하이라키에 있는 객체들 못 끌어옴
        target_body = this.gameObject.GetComponent<SpriteRenderer>(); // 프리팹 상태에선 하이라키에 있는 객체들 못 끌어옴
        //OnbecameVisible,OnbecameInvisible은 Sprite rendererer에 적용 안됨(mesh renderer에 적용됨.) SpriteRenderer는 visible 속성이 있음

        x_direction = Random.Range(-1.5f, 1.5f);
        y_direction = Random.Range(-1.5f, 1.5f);
    }

    void Update()
    {
        if (Time_Left.game_time > 0)
        {
            if (target_body.isVisible)
                transform.position = transform.position + new Vector3(x_direction, y_direction, 0) * 0.002f * Time.timeScale;  //timeScale은 모두 공유
            else
                Destroy(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

}