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
                if (hit.collider.tag == "Target" && !Spawner.IsBonus)
                {
                    Destroy(hit.collider.gameObject);
                    score.score += 10;
                }
                else if (hit.collider.tag == "Hostile" && !Spawner.IsBonus)
                {
                    Destroy(hit.collider.gameObject);
                    score.score -= 30;
                }
                else if(hit.collider.tag == "Special")
                {
                    Destroy(hit.collider.gameObject);
                    StartCoroutine( Before_Bonus() );
                }
                else if(hit.collider.tag == "Bonus_Target")
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
        Spawner.spawn = false;
        yield return new WaitForSeconds(1f);
        Spawner.IsBonus = true;
        yield return new WaitForSeconds(7f);
        Spawner.IsBonus = false;
        TimeManager.time_flow = 1;
        Spawner.spawn = true;
    }

    void Update()
    {
        if(Spawner.spawn || Spawner.IsBonus)
            touched();
    }
}