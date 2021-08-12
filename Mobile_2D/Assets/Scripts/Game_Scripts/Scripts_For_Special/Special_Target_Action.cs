using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Special_Target_Action : MonoBehaviour //일반적으로 MonoBehaviour을 상속. 그래서 Start, Update 등 쓸 수 있는 것임
{
    public GameObject blackhole;
    public Time_Left time;
    public GameObject pause_icon;

    public SpriteRenderer Special_Sprite;
    public Sprite[] Monkey_Images;
    public static int Image_Index;

    public float vib_intensity;
    //*Special_Images에서 넘어옴

    public static bool InCorner;
    public static Vector3 Des;
    private Vector3 velo;
    public bool NotInAction;
    private bool tease;
    private bool scaleUp;
    private bool arrived_blackhole;
    private bool ToBlackhole;

    void Awake()
    {
        NotInAction = true;
        tease = false;
        scaleUp = false;
        arrived_blackhole = false;
        ToBlackhole = false;

        InCorner = false;  // 구석에선 못 도망
        velo = Vector3.zero;

        Des = transform.position; //처음엔 움직일 거 없으니까 지금 위치
    }

    void Start()
    {
        blackhole = GameObject.Find("BlackHole");
        pause_icon = GameObject.Find("Pause");
        time = GameObject.Find("Time").GetComponent<Time_Left>();
        Image_Index = 0;

    }

    void Update()
    {
        Special_Sprite.sprite = Monkey_Images[Image_Index];
        if (!Pause.IsPause)
        {
            if (ToBlackhole)
                Blackholing();
            if (tease || arrived_blackhole)
                Vibration();
            if (scaleUp)
                MakeScaleUp();
        }

        if (!Pause.IsPause && NotInAction)
        {
            if(!Mathf.Approximately(transform.position.magnitude , Des.magnitude))
                transform.position = Vector3.SmoothDamp(transform.position, Des, ref velo, 0.15f);
            else
                Image_Index = 0;
        }
    }

    public IEnumerator BONUS_EVENT()
    {
        pause_icon.GetComponent<Button>().enabled = false;
        NotInAction = false;
        Image_Index = 1;
        TimeManager.time_flow = false;
        yield return new WaitForSeconds(1f);
        arrived_blackhole = true;
        yield return new WaitForSeconds(1f);
        arrived_blackhole = false;
        ToBlackhole = true;
    }


    public IEnumerator PAUSE_EVENT(GameObject pause)
    {
        Destroy(blackhole);
        pause.GetComponent<BoxCollider2D>().enabled = false;
        pause_icon.GetComponent<Button>().enabled = false;
        TimeManager.time_flow = false;
        NotInAction = false;
        Image_Index = 3;
        transform.position = new Vector3(pause.transform.position.x-1 , pause.transform.position.y-1 ,0);

        //행동
        yield return new WaitForSeconds(2f);
        pause_icon.GetComponent<Rigidbody2D>().gravityScale = 2f;

        //비웃는 행동
        Image_Index = 2;
        transform.position = new Vector3(0,0,0);
        tease = true;
        yield return new WaitForSeconds(1f);

        scaleUp = true;
        yield return new WaitForSeconds(3f);

        Destroy(this.gameObject);
        TimeManager.time_flow = true;
        time.time_speed = 2;
    }

    void Idle()
    {
        //약간의 흔들림
    }
    void Vibration()
    {
        //진동
        transform.position += Random.insideUnitSphere * vib_intensity;
    }
    void MakeScaleUp()
    {
        transform.localScale += new Vector3(0.05f, 0.05f, 0);
    }
    void Blackholing()
    {
        if (transform.localScale.x < 0f && transform.localScale.y<0f)  //(Mathf.Approximately(transform.localScale.magnitude, 0f)) 하면 true 반환 안 함
        {
            pause_icon.GetComponent<Button>().enabled = true;
            Spawner.IsBonus = true;
            Destroy(this.gameObject);
            Destroy(blackhole.gameObject);
        }
        else
        {
            transform.Rotate(0, 0, 1f);
            transform.localScale -= new Vector3(0.002f, 0.002f, 0);
        }
    }
}

//(Mathf.Approximately(): 대체로 true를 반환하는 경우가 잘 없음

// *velocity(3D 작업에서도), SmoothDamp, Lerp(아마도) 등은 완벽하게 목적지로 도착하지 않음
// *그래서 Mathf.Approximately(비교대상1, 비교대상2) 를 사용. 둘이 비슷하면 true 반환.
// *참고로 비교대상은 실수값


// *부드럽게 이동시키기
// *(Vector3.SmoothDamp(transform.position, target, ref velo, 0.1f);
// *Vector3.Lerp( transform.position,target,속도 (1f가 최대) );