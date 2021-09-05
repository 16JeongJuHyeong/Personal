using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static bool time_flow;
    public static float game_time;
    public static bool IsBonus;


    [SerializeField] private AudioSource Background_Music;
    [SerializeField] private GameObject Over_UI;
    [SerializeField] private Text Time_Text;

    public float time_speed;
    private float bonus_time_left;

    void Awake()
    {
        Time.timeScale = 0f;
        IsBonus = false;
        game_time = 60f;
        time_flow = false;
        bonus_time_left = 7f;
        time_speed = 1f;
        Over_UI.SetActive(false);
    }


    void Update()
    {
        Game_Timer();
        Bonus_Timer();
    }

    void Game_Timer()
    {
        if (time_flow)
        {
            game_time -= Time.deltaTime * time_speed;
            Time_Text.text = "Time: " + game_time.ToString("N0") + "sec";
            //*소수점 제거시키는 방법: N(x) - x자리까지 소수점 출력
            //*Time.deltaTime: 프레임과 프레임 사이의 시간
            //*ToString: 문자열 형태로 변환
        }
        if (game_time < 1f)
        {
            Background_Music.Stop();
            time_flow = false;
            Time_Text.enabled = false;
            Over_UI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    void Bonus_Timer()
    {
        if (IsBonus && Time.timeScale > 0f)
        {
            bonus_time_left -= Time.deltaTime;
            if (bonus_time_left < 0f)
            {
                Background_Music.Play();
                IsBonus = false;
                time_flow = true;
            }
        }
    }
}