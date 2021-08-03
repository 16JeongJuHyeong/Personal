using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Target_action2 : MonoBehaviour //일반적으로 MonoBehaviour을 상속. 그래서 Start, Update 등 쓸 수 있는 것임
{
    protected virtual void Set_Destination() { } // 하위 클래스에서 재정의 할 수 있게 함
    //protected는 같은 클래스(부모,자식들) 끼리만 쓸 수 있는 영역


    //부드럽게 이동시키기
    //Vector3.SmoothDamp(transform.position, target, ref velo, 0.1f);

}