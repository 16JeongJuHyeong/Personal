﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecting : MonoBehaviour
{
    public Score score;

    //void touch()
    //{
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Vector2 click_point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        //*좌표계엔 Screen 좌표, World좌표 , 00  등이 있음.
    //        //*카메라는 기본적으로 Screen좌표기 때문에 World좌표를 사용하는 객체의 위치에 맞게 변환
    //        RaycastHit2D hit = Physics2D.Raycast(click_point, Vector2.zero);
    //        if (hit.collider != null)
    //        {
    //            if(hit.collider.tag == "Special" && Special_Target_Action.InCorner)
    //                StartCoroutine(Before_Bonus());
    //            else if (hit.collider.tag == "Target" && !Spawner.IsBonus && !Pause.IsPause)  //보너스 타임엔 건드릴 수 없음
    //            {
    //                Destroy(hit.collider.gameObject);
    //                score.score += 10;
    //            }
    //            else if (hit.collider.tag == "Hostile" && !Spawner.IsBonus && !Pause.IsPause)  //보너스 타임엔 건드릴 수 없음
    //            {
    //                Destroy(hit.collider.gameObject);
    //                score.score -= 30;
    //            }
    //            else if(hit.collider.tag == "Bonus_Target" && !Pause.IsPause)  // 정지시간 아니면 건드릴 수 있지만, 보너스 타임 끝나곤 못 건드리길 원하면 조건문에 IsBonus 넣기
    //            {
    //                Destroy(hit.collider.gameObject);
    //                score.score += 10;
    //            }
    //        }
    //    }
    //}
    //void OnMouseDown()
    //{
    //    Vector2 click_point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    RaycastHit2D hit = Physics2D.Raycast(click_point, Vector2.zero);
    //    if (hit.collider != null)
    //    {
    //        if (hit.collider.tag == "Special" && Special_Target_Action.InCorner)
    //            StartCoroutine(Before_Bonus());
    //        else if (hit.collider.tag == "Target" && !Spawner.IsBonus && !Pause.IsPause)  //보너스 타임엔 건드릴 수 없음
    //        {
    //            Destroy(hit.collider.gameObject);
    //            score.score += 10;
    //        }
    //        else if (hit.collider.tag == "Hostile" && !Spawner.IsBonus && !Pause.IsPause)  //보너스 타임엔 건드릴 수 없음
    //        {
    //            Destroy(hit.collider.gameObject);
    //            score.score -= 30;
    //        }
    //        else if (hit.collider.tag == "Bonus_Target" && !Pause.IsPause)  // 정지시간 아니면 건드릴 수 있지만, 보너스 타임 끝나곤 못 건드리길 원하면 조건문에 IsBonus 넣기
    //        {
    //            Destroy(hit.collider.gameObject);
    //            score.score += 10;
    //        }
    //    }
    //    else
    //        Debug.Log("null");
    //
    //}



    //여기 하는 동안 다른 곳이 멈추는 게 아니라 코루틴에서만 시간동안 잠깐 멈춤
    //IEnumerator Before_Bonus() //보너스 시작하기 전 잠깐 딜레이 + 애니메이션을 위한 딜레이
    //{
    //    TimeManager.time_flow = 0;
    //    Special_Images.Image_Index = 2;
    //    yield return new WaitForSeconds(2f);
    //    Destroy(GameObject.Find("Special(Clone)"));
    //    Spawner.IsBonus = true;
    //}

}