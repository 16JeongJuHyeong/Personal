using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_byClass : MonoBehaviour //*MonoBehaviour 클래스 상속. 그래서 Start, Update 등 기본적인 함수 사용 가능
{
    protected SpriteRenderer target_body; // Special을 제외한 모든 대상은 가지는 속성. Special은 어차피 이런 움직임이 없음

    protected float x_direction; // x축 방향 , 모든 대상이 가지는 속성
    protected float y_direction; // y축 방향 , 모든 대상이 가지는 속성

    protected Score score;
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>(); //*<스크립트 이름>: 스크립트 컴포넌트 가져오기
        target_body = this.gameObject.GetComponent<SpriteRenderer>(); // *프리팹 상태에선 하이라키에 있는 객체들 못 끌어옴
        x_direction = Random.Range(-1.5f, 1.5f); //방향은 램덤 , 모두
        y_direction = Random.Range(-1.5f, 1.5f); //방향은 랜덤 , 모두
    }
    protected virtual void OnMouseDown() { } //밑에서 각자 재정의
}