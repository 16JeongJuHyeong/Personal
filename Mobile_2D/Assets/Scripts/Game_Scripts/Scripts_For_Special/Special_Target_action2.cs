using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Target_action2 : MonoBehaviour //일반적으로 MonoBehaviour을 상속. 그래서 Start, Update 등 쓸 수 있는 것임
{
    [SerializeField]
    private GameObject Left_Top_End;
    [SerializeField]
    private GameObject Left_Bottom_End;
    [SerializeField]
    private GameObject Right_Top_End;
    [SerializeField]
    private GameObject Right_Bottom_End;

    public static bool InCorner;
    //protected는 같은 클래스(부모,자식들) 끼리만 쓸 수 있는 영역
    public static Vector3 Des;
    private Vector3 velo;
    void Start()
    {
        InCorner = false;  // 구석에선 못 도망
        velo = Vector3.zero;
        Des = transform.position;
    }

    void Update()
    {
        if ((transform.position - Left_Top_End.transform.position).magnitude < 2f)
            InCorner = true;
        else if ((transform.position - Left_Bottom_End.transform.position).magnitude < 2f)
            InCorner = true;
        else if ((transform.position - Right_Top_End.transform.position).magnitude < 2f)
            InCorner = true;
        else if ((transform.position - Right_Bottom_End.transform.position).magnitude < 2f)
            InCorner = true;
        if (!Pause.IsPause)
        {
            if (!Mathf.Approximately(transform.position.magnitude, Des.magnitude))
                transform.position = Vector3.SmoothDamp(transform.position, Des, ref velo, 0.2f);
            //transform.position = Vector3.SmoothDamp(transform.position, Des, ref velo, 0.2f);
            //transform.position = Vector3.Lerp(transform.position, Des, 0.1f);
        }
    }
}


// velocity(3D 작업에서도), SmoothDamp, Lerp(아마도) 등은 완벽하게 목적지로 도착하지 않음
// 그래서 Mathf.Approximately(비교대상1, 비교대상2) 를 사용. 둘이 비슷하면 true 반환.
// 참고로 비교대상은 실수값


//부드럽게 이동시키기
//Vector3.SmoothDamp(transform.position, target, ref velo, 0.1f);
//Vector3.Lerp( transform.position,target,속도 (1f가 최대) );