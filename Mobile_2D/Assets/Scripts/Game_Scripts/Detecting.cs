using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detecting : MonoBehaviour
{
    public Score score;

    void touched()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 click_point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(click_point, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Target" && !Spawner.IsBonus && !Pause.IsPause)  //보너스 타임엔 건드릴 수 없음
                {
                    Destroy(hit.collider.gameObject);
                    score.score += 10;
                }
                else if (hit.collider.tag == "Hostile" && !Spawner.IsBonus && !Pause.IsPause)  //보너스 타임엔 건드릴 수 없음
                {
                    Destroy(hit.collider.gameObject);
                    score.score -= 30;
                }
                else if(hit.collider.tag == "Bonus_Target" && !Pause.IsPause)  // 정지시간 아니면 건드릴 수 있지만, 보너스 타임 끝나곤 못 건드리길 원하면 조건문에 IsBonus 넣기
                {
                    Destroy(hit.collider.gameObject);
                    score.score += 10;
                }
            }
        }
    }

    IEnumerator Before_Bonus()
    {
        TimeManager.time_flow = 0;
        yield return new WaitForSeconds(1f);
        Spawner.IsBonus = true;
    }

    void Update()
    {
        touched();
    }
}