using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Collider_Action : MonoBehaviour
{
    protected AudioSource Clicked_Sound;

    protected const float ToLeft = -1.5f;
    protected const float ToRight = 1.5f;
    protected const float ToBottom = -1.5f;
    protected const float ToTop = 1.5f;
    protected Vector3 To_Left_Bottom = new Vector3(ToLeft,ToBottom,0);
    protected Vector3 To_Right_Bottom = new Vector3(ToRight,ToBottom,0);
    protected Vector3 To_Left_Top = new Vector3(ToLeft,ToTop,0);
    protected Vector3 To_Right_Top = new Vector3(ToRight,ToTop,0);
    //상속해줌으로써 매번 변수를 선언할 필요 없게 한다 ->재사용

    protected const float Reverse_Distance = 0.5f;

    protected virtual void OnTriggerStay2D(Collider2D other) { }
    protected virtual void OnMouseDown() { }
    //Special Target의 부분(자식)마다 기능이 달라서 아래에서 정의

    void Start()
    {
        Clicked_Sound = GameObject.Find("Clicked_Sound").GetComponent<AudioSource>();
    }

}