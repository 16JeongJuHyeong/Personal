using System.Collections;
using System.Collections.Specialized;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static bool IsBonus;
    //IsBonus==true이면 Coroutine 실행

    [SerializeField]
    private GameObject bee_prefab;
    [SerializeField]
    private GameObject hostile_prefab;
    [SerializeField]
    private GameObject special_prefab;

    void Start()
    {
        IsBonus = false;
        StartCoroutine(Target_Spawn());
        StartCoroutine(Hostile_Spawn());
        StartCoroutine(Special_Spawn());
    }
    void Update()
    {
        if (Time_Left.game_time < 0f)
            TimeManager.time_flow = 0;
    }

    IEnumerator Target_Spawn()
    {
        if ((TimeManager.time_flow > 0) && !Pause.IsPause)   //if (spawn && (TimeManager.time_flow > 0))
        {
            float x = Random.Range(-1.5f, 1.5f);
            float y = Random.Range(-2f, 2f);
            Vector3 spawn_position = new Vector3(x, y, 0);
            Instantiate(bee_prefab, spawn_position, Quaternion.Euler(0, 0, 0));  // 프리팹 복사본(clone) 생성. (복제할 프리팹, 복제 위치, 복제 rotation)
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(Target_Spawn());
    }

    IEnumerator Hostile_Spawn()
    {
        if ((TimeManager.time_flow > 0) && !Pause.IsPause )  //if (spawn && (TimeManager.time_flow > 0))
        {
            float x = Random.Range(-1.5f, 1.5f);
            float y = Random.Range(-2f, 2f);
            Vector3 spawn_position = new Vector3(x, y, 0);
            Instantiate(hostile_prefab, spawn_position, Quaternion.Euler(0, 0, 0));
        }
        yield return new WaitForSeconds(10f);
        StartCoroutine(Hostile_Spawn());
    }

    IEnumerator Special_Spawn()  //업데이트 함수로 spawn 구현 시 너무 많이 소환. Default는 초당 10개
    {
        if (IsBonus && !Pause.IsPause)  // 일시정지 했을 때 보너스 안 나오게 설정
        {
            float x = Random.Range(-1.5f, 1.5f);
            float y = Random.Range(-2f, 2f);
            Vector3 spawn_position = new Vector3(x, y, 0);
            Instantiate(special_prefab, spawn_position, Quaternion.Euler(0, 0, 0));
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Special_Spawn());
    }
}