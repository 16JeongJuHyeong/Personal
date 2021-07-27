using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Left : MonoBehaviour
{
    public Spawner spawner;

    [SerializeField]
    private Text time;

    public float game_time;

    void Start()
    {
        game_time = 60f;
    }

    void Update()
    {
        if(spawner.spawn)
        {
            game_time -= Time.deltaTime;
            time.text = "Time: " + game_time.ToString("N0") + "sec";
        }
        if (game_time < 0)
        {
            this.gameObject.SetActive(false);
        }
    }

}