using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_script : MonoBehaviour
{
    private Animator animator;

    //*애니메이터에서 애니메이션 간 이동을 도와줄 변수들이 있음.
    //*변수들 값만 만족하면 애니메이션을 바꿔주지만, 값을 바꾸려면 스크립트 사용해야 함.
    //*스크립트에서 애니메이션을 가진 객체의 Animator 컴포넌트를 받은 후
    //*변수를 바꿔주는 함수를 추가한다.
    //*그리고 애니메이션의 이벤트를 이용해 함수를 사용해 영상 재생 후 알아서 애니메이션 전환하도록 한다.
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Shake_Stop()
    {
        animator.SetBool("shake",false);
    }
    void Shake_Start()
    {
        animator.SetBool("shake", true);
    }
}