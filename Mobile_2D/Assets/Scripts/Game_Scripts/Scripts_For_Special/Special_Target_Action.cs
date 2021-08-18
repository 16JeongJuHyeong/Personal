﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Special_Target_Action : MonoBehaviour //일반적으로 MonoBehaviour을 상속. 그래서 Start, Update 등 쓸 수 있는 것임
{
    const float Blackhole_Rotate_speed = 2f;
    const float Blackhole_SizeDown_speed = 0.02f;
    const float Vib_intensity = 0.007f;
    const float Run_speed = 1f;
    const float Moving_speed_When_Clicked = 0.15f;
    const float Distance_Between_Position_Des = 0.01f;
    const int Idle_Image_num = 0;
    const int Panic_Image_num = 1;
    const int Moving_Image_num = 2;
    const int Giggling_Image_num = 3;
    const int Teasing_Image_num = 4;

    public static Vector3 Des;
    public bool NotInAction;

    [SerializeField] private SpriteRenderer Special_Sprite;
    [SerializeField] private Sprite[] Monkey_Images;

    private Pause Pause_To_Drop;
    private Time_Left time;
    private GameObject blackhole;
    private BoxCollider2D pause_icon_collider;
    private Vector3 velo;
    private SpriteRenderer Check_Special_Visible;

    private int Image_Index;
    private bool tease;
    private bool arrived_blackhole;
    private bool ToBlackhole;
    private bool run;

    private AudioSource Background_Music;
    private AudioSource Bonus_Music;
    private AudioSource Giggle_Sound_1;
    private AudioSource Giggle_Sound_2;
    private AudioSource Panic_Sound;

    public Hostile_Text hostile_text;

    void Start()
    {
        hostile_text = GameObject.Find("hostile_text").GetComponent<Hostile_Text>();

        Special_Sprite.sprite = Monkey_Images[Image_Index];
        NotInAction = true;
        tease = false;
        arrived_blackhole = false;
        ToBlackhole = false;
        run = false;
        
        Background_Music = GameObject.Find("Background_Sound").GetComponent<AudioSource>();
        Bonus_Music = GameObject.Find("Bonus_Sound").GetComponent<AudioSource>();
        Giggle_Sound_1 = GameObject.Find("Giggle_Sound_1").GetComponent<AudioSource>();
        Giggle_Sound_2 = GameObject.Find("Giggle_Sound_2").GetComponent<AudioSource>();
        Panic_Sound = GameObject.Find("Panic_Sound").GetComponent<AudioSource>();
        pause_icon_collider = GameObject.Find("Pause").GetComponent<BoxCollider2D>();
        Pause_To_Drop = GameObject.Find("Pause").GetComponent<Pause>();
        time = GameObject.Find("Time").GetComponent<Time_Left>();

        Check_Special_Visible = GetComponent<SpriteRenderer>();

        blackhole = GameObject.Find("BlackHole(Clone)");

        velo = Vector3.zero;
        Des = transform.position;
    }


    void Update()
    {
        if (Time_Left.game_time < 1f)
            Destroy(this.gameObject);
        else
        {
            Action();
            Check_Hostile();
        }
    }

    void Check_Hostile()
    {
        if (hostile_text == null)
            return;
        else
        {
            hostile_text.Hostile_Alert(this);
        }
    }

    public IEnumerator BONUS_EVENT()
    {
        Background_Music.Pause();
        WaitForSeconds wait = new WaitForSeconds(1f);
        pause_icon_collider.enabled = false;
        NotInAction = false;
        Image_Index = Panic_Image_num;
        TimeManager.time_flow = false;
        yield return wait;
        arrived_blackhole = true;
        yield return wait;
        arrived_blackhole = false;
        ToBlackhole = true;
        Panic_Sound.Play();
    }


    public IEnumerator PAUSE_EVENT(GameObject pause)
    {
        Background_Music.Pause();
        WaitForSeconds wait = new WaitForSeconds(1f);
        Destroy(blackhole);
        pause_icon_collider.enabled = false;
        TimeManager.time_flow = false;
        NotInAction = false;
        transform.position = new Vector3(pause.transform.position.x-1 , pause.transform.position.y-1 ,0);
        Pause_To_Drop.drop = true;
        yield return wait;
        transform.position = Vector2.zero;
        tease = true;
        yield return wait;
        Giggle_Sound_1.Play();
        Image_Index = Giggling_Image_num;
        yield return wait;
        tease = false;
        Giggle_Sound_2.Play();
        Image_Index = Teasing_Image_num;
        run = true;
        time.time_speed = 2;
        TimeManager.time_flow = true;
        Background_Music.Play();  //음악도 빨리 흐르면 좋을 듯
    }

    void Vibration()
    {
        transform.position += Random.insideUnitSphere * Vib_intensity;
    }
    void RunAway()
    {
        if (Check_Special_Visible.isVisible)
            transform.position += Vector3.left * Run_speed;
        else
            Destroy(this.gameObject);
    }
    void Blackholing()
    {
        if (transform.localScale.x < 0f && transform.localScale.y<0f)
        {
            Bonus_Music.Play();
            pause_icon_collider.enabled = true;
            Spawner.IsBonus = true;
            Destroy(blackhole);
            Destroy(this.gameObject);
        }
        else
        {
            transform.Rotate(0, 0, Blackhole_Rotate_speed);
            transform.localScale -= new Vector3(Blackhole_SizeDown_speed, Blackhole_SizeDown_speed, 0);
        }
    }

    void Action()
    {
        Special_Sprite.sprite = Monkey_Images[Image_Index];
        if (!Pause.IsPause)
        {
            if (NotInAction)
            {
                //if Mathf.Approximately는 true를 잘 반환 안 해서 바꿨음
                if (Mathf.Abs(transform.position.sqrMagnitude - Des.sqrMagnitude) > Distance_Between_Position_Des)  //sqrMagnitude , magnitude: magnitude은 제곱근 계산해서 메모리 낭비
                {
                    Image_Index = Moving_Image_num;
                    transform.position = Vector3.SmoothDamp(transform.position, Des, ref velo, Moving_speed_When_Clicked);
                }
                else
                    Image_Index = Idle_Image_num;
            }
            else
            {
                if (ToBlackhole)
                    Blackholing();
                else if (tease || arrived_blackhole)
                    Vibration();
                else if (run)
                    RunAway();
            }
        }
    }
    public void Special_Alert(Hostile_Text Hostile_)
    {
        hostile_text = Hostile_;


    }
}

//(Mathf.Approximately(): 대체로 true를 반환하는 경우가 잘 없음

// *velocity(3D 작업에서도), SmoothDamp, Lerp(아마도) 등은 완벽하게 목적지로 도착하지 않음
// *그래서 Mathf.Approximately(비교대상1, 비교대상2) 를 사용. 둘이 비슷하면 true 반환.
// *참고로 비교대상은 실수값


// *부드럽게 이동시키기
// *(Vector3.SmoothDamp(transform.position, target, ref velo, 0.1f);
// *Vector3.Lerp( transform.position,target,속도 (1f가 최대) );