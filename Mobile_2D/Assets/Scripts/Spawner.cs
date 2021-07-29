using System.Collections;
using System.Collections.Specialized;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static bool spawn;

    [SerializeField]
    private GameObject bee_prefab;
    [SerializeField]
    private GameObject hostile_prefab;

    void Start()
    {
        Spawner.spawn = false;
        StartCoroutine(Target_Spawn());
        StartCoroutine(Hostile_Spawn());
    }
    void Update()
    {
        if (Time_Left.game_time < 0f)
        {
            Time.timeScale = 0f;
            spawn = false;
        }
    }

    IEnumerator Target_Spawn()
    {
        if (spawn && (Time_Left.game_time>0)) 
        {
            float x = Random.Range(-1.5f, 1.5f);
            float y = Random.Range(-2f, 2f);
            Vector3 spawn_position = new Vector3(x, y, 0);
            Instantiate(bee_prefab, spawn_position, Quaternion.Euler(0, 0, 0));
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(Target_Spawn());
    }
    IEnumerator Hostile_Spawn()
    {
        if (spawn && (Time_Left.game_time > 0))
        {
            float x = Random.Range(-1.5f, 1.5f);
            float y = Random.Range(-2f, 2f);
            Vector3 spawn_position = new Vector3(x, y, 0);
            Instantiate(hostile_prefab, spawn_position, Quaternion.Euler(0, 0, 0));
        }
        yield return new WaitForSeconds(10f);
        StartCoroutine(Hostile_Spawn());
    }
}
