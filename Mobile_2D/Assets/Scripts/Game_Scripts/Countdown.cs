using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField]
    private GameObject Pause_Button;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Counting", true);
    }

    void Count_Over()
    {
        animator.SetBool("Counting", false);
        Pause_Button.GetComponent<Button>().interactable = true;
        Pause.IsPause = false;
        if (!Spawner.IsBonus)
            TimeManager.time_flow = 1;
        this.gameObject.SetActive(false);
    }
    //애니메이션 이벤트를 사용하면 업데이트로 시간 확인할 필요 없이 알아서 함수를 사용해줌
}