using System.Collections;
using System.Collections.Specialized;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool Special_trig;
    private float hostile_spawn_time;
    public static bool IsBonus;

    [SerializeField]
    private GameObject target_prefab;
    [SerializeField]
    private GameObject hostile_prefab;
    [SerializeField]
    private GameObject special_prefab;
    [SerializeField]
    private GameObject bonus_prefab;

    void Start()
    {
        hostile_spawn_time = 0f;
        Special_trig = true;
        IsBonus = false;
        StartCoroutine(Target_Spawn());   
        StartCoroutine(Bonus_Spawn());
    }

    void Update()
    {
        if (Time_Left.game_time < 0f)
            TimeManager.time_flow = false;
        if (Time_Left.game_time < 30f && Special_trig)
        {
            Instantiate(special_prefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
            Special_trig = false;
        }
        if (TimeManager.time_flow && !Pause.IsPause)
            hostile_Spawn();
    }

    private void hostile_Spawn()
    {
        hostile_spawn_time += Time.deltaTime;
        if (hostile_spawn_time > 15f && GameObject.Find("hostile(Clone)") == null) //시간이 되어도 아직 게임에 객체가 남아있으면 스폰 안 함
        {
            float x = Random.Range(-2.5f, 2.5f);
            float y = Random.Range(-4f, 4f);
            Vector3 spawn_position = new Vector3(x, y, 0);
            Instantiate(hostile_prefab, spawn_position, Quaternion.Euler(0, 0, 0));
            hostile_spawn_time = 0f;
        }
    }
    //코루틴의 WaitForSeconds가 게임에 구현한 일시정지에 효과가 없어 Update함수로 처리

    IEnumerator Target_Spawn()
    {
        if (TimeManager.time_flow && !Pause.IsPause)
        {
            float x = Random.Range(-2.5f, 2.5f);
            float y = Random.Range(-4f, 4f);
            Vector3 spawn_position = new Vector3(x, y, 0);
            Instantiate(target_prefab, spawn_position, Quaternion.Euler(0, 0, 0));
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(Target_Spawn());
    }

    IEnumerator Bonus_Spawn()
    {
        if (IsBonus && !Pause.IsPause)
        {
            float x = Random.Range(-2.5f, 2.5f);
            float y = Random.Range(-4f, 4f);
            Vector3 spawn_position = new Vector3(x, y, 0);
            Instantiate(bonus_prefab, spawn_position, Quaternion.Euler(0, 0, 0));
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Bonus_Spawn());
    }
}