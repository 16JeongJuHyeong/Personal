using System.Collections;
using System.Collections.Specialized;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    const float Spawn_min_x = -2.5f;
    const float Spawn_max_x = 2.5f;
    const float Spawn_min_y = -4f;
    const float Spawn_max_y = 4f;
    const float Hostile_Spawn_Term = 15f;
    Vector3 Blackhole_position = new Vector3(-4, -8, 0);

    private bool Special_trig;
    private float Hostile_Spawn_Time;
    public static bool IsBonus;

    public bool Hostile_Is_In_Game;

    [SerializeField] private GameObject target_prefab;
    [SerializeField] private GameObject hostile_prefab;
    [SerializeField] private GameObject special_prefab;
    [SerializeField] private GameObject bonus_prefab;
    [SerializeField] private GameObject blackhole_prefab;

    private GameObject hostile_object;
    private GameObject special_object;

    void Start()
    {
        Hostile_Is_In_Game = false;
        Hostile_Spawn_Time = 0f;
        Special_trig = true;
        IsBonus = false;
        StartCoroutine(Target_Spawn());   
        StartCoroutine(Bonus_Spawn());
    }

    void Update()
    {
        if (Time_Left.game_time > 1f)
        {
            Special_Spawn();
            Hostile_Spawn();
        }
        else
            TimeManager.time_flow = false;
    }

    private void Special_Spawn()
    {
        if (Time_Left.game_time < 30f && Special_trig)
        {
            Instantiate(special_prefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
            Instantiate(blackhole_prefab, Blackhole_position, Quaternion.Euler(0, 0, 0));
            Special_trig = false;
        }
    }

    private void Hostile_Spawn()
    {
        if (TimeManager.time_flow && !Pause.IsPause)
        {
            Hostile_Spawn_Time += Time.deltaTime;
            if ( (Hostile_Spawn_Time > Hostile_Spawn_Term) && !Hostile_Is_In_Game) //시간이 되어도 아직 게임에 객체가 남아있으면 스폰 안 함
            {
                Hostile_Spawn_Time = 0f;
                float x = Random.Range(Spawn_min_x, Spawn_max_x);
                float y = Random.Range(Spawn_min_y, Spawn_max_y);
                Vector3 spawn_position = new Vector3(x, y, 0);
                Instantiate(hostile_prefab, spawn_position, Quaternion.Euler(0, 0, 0));
                Hostile_Is_In_Game = true;
            }
        }
    }
    //코루틴의 WaitForSeconds가 게임에 구현한 일시정지에 효과가 없어 Update함수로 처리

    IEnumerator Target_Spawn()
    {
        WaitForSeconds Target_Spawn_Time = new WaitForSeconds(0.7f);
        while(Time_Left.game_time>0f)
        {
            if (TimeManager.time_flow && !Pause.IsPause)
            {
                float x = Random.Range(Spawn_min_x, Spawn_max_x);
                float y = Random.Range(Spawn_min_y, Spawn_max_y);
                Vector3 spawn_position = new Vector3(x, y, 0);
                Instantiate(target_prefab, spawn_position, Quaternion.Euler(0, 0, 0));
            }
            yield return Target_Spawn_Time;
        }
    }
    
    IEnumerator Bonus_Spawn()
    {
        WaitForSeconds Bonus_Spawn_Time = new WaitForSeconds(0.1f);
        while (Time_Left.game_time > 0f)
        {
            if (IsBonus && !Pause.IsPause)
            {
                float x = Random.Range(Spawn_min_x, Spawn_max_x);
                float y = Random.Range(Spawn_min_y, Spawn_max_y);
                Vector3 spawn_position = new Vector3(x, y, 0);
                Instantiate(bonus_prefab, spawn_position, Quaternion.Euler(0, 0, 0));
            }
            yield return Bonus_Spawn_Time;
        }
    }
}
    //*밑의 코드는 "재귀함수" 형태로 호출한 함수가 끝나지 않은 상태에서 무한대로 함수를 불러오기 때문에 메모리가 크게 낭비됨.

    //IEnumerator Target_Spawn()
    //{
    //    if (TimeManager.time_flow && !Pause.IsPause)
    //    {
    //        float x = Random.Range(-2.5f, 2.5f);
    //        float y = Random.Range(-4f, 4f);
    //        Vector3 spawn_position = new Vector3(x, y, 0);
    //        Instantiate(target_prefab, spawn_position, Quaternion.Euler(0, 0, 0));
    //    }
    //    yield return new WaitForSeconds(1f);
    //    StartCoroutine(Target_Spawn());
    //}
    //
    //IEnumerator Bonus_Spawn()
    //{
    //    if (IsBonus && !Pause.IsPause)
    //    {
    //        float x = Random.Range(-2.5f, 2.5f);
    //        float y = Random.Range(-4f, 4f);
    //        Vector3 spawn_position = new Vector3(x, y, 0);
    //        Instantiate(bonus_prefab, spawn_position, Quaternion.Euler(0, 0, 0));
    //    }
    //    yield return new WaitForSeconds(0.1f);
    //    StartCoroutine(Bonus_Spawn());
    //}
