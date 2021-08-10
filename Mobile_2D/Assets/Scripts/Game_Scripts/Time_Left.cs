using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Left : MonoBehaviour
{
    [SerializeField]
    private GameObject Over_UI;
    [SerializeField]
    private Text time;
    [SerializeField]
    private Text Guide;

    public static float game_time;

    void Start()
    {
        Over_UI.SetActive(false);
        game_time = 60f;
    }

    void Update()
    {
        if (!Pause.IsPause && TimeManager.time_flow>0)
        {
            game_time -= Time.deltaTime;
            time.text = "Time: " + game_time.ToString("N0") + "sec";
            //*소수점 제거시키는 방법: N(x) - x자리까지 소수점 출력
            //*Time.deltaTime: 프레임과 프레임 사이의 시간
            //*ToString: 문자열 형태로 변환
        }
        if (game_time < 0)
        {
            TimeManager.time_flow = 0;
            Over_UI.SetActive(true);
            this.gameObject.SetActive(false);
        }
        if(GameObject.Find("Special(Clone)") != null)
            Guide.text = "GUIDE TEXT HERE";
        else
        {
            Guide.text = " ";
        }
    }
}