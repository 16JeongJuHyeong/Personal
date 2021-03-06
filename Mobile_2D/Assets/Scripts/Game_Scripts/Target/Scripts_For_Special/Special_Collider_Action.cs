using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Special_Collider_Action : MonoBehaviour
{
    protected AudioSource Clicked_Sound;
    protected Transform Special;
    protected Special_Target_Action Special_Action;

    protected const float ToLeft = -1.5f;
    protected const float ToRight = 1.5f;
    protected const float ToBottom = -1.5f;
    protected const float ToTop = 1.5f;
    protected const float Reverse_Distance = 0.5f;
    protected Vector3 To_Left_Bottom = new Vector3(ToLeft,ToBottom,0);
    protected Vector3 To_Right_Bottom = new Vector3(ToRight,ToBottom,0);
    protected Vector3 To_Left_Top = new Vector3(ToLeft,ToTop,0);
    protected Vector3 To_Right_Top = new Vector3(ToRight,ToTop,0);
    //상속해줌으로써 매번 변수를 선언할 필요 없게 한다 ->재사용


    protected abstract void OnTriggerStay2D(Collider2D other);
    protected abstract void OnMouseDown();
    //Special Target의 자식 오브젝트마다 기능이 달라서 아래에서 정의
    void Start()
    {
        Clicked_Sound = GameObject.Find("Clicked_Sound").GetComponent<AudioSource>();
        Special = this.gameObject.transform.parent;
        Special_Action = this.gameObject.transform.parent.GetComponent<Special_Target_Action>();
    }
}