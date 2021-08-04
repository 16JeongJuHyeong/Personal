using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Left : MonoBehaviour
{
    public GameObject Over_UI;
    [SerializeField]
    private Text time;

    public static float game_time;

    void Start()
    {
        Over_UI.SetActive(false);
        game_time = 120f;
    }

    void Update()
    {
        if (!Pause.IsPause && TimeManager.time_flow>0) //if (Spawner.spawn && TimeManager.time_flow>0) 
        {
            game_time -= Time.deltaTime;
            time.text = "Time: " + game_time.ToString("N0") + "sec";
            //소수점 제거시키는 방법: N(x) - x자리까지 소수점 출력

        }
        if (game_time < 0)
        {
            TimeManager.time_flow = 0;
            Over_UI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}