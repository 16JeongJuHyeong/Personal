﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detecting : MonoBehaviour
{
    public Spawner spawner;
    public Time_Left time_left;

    public Text Score_Text;
    private int Score;
    void touched()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 click_point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(click_point, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Target")
                {
                    Destroy(hit.collider.gameObject);
                    Score += 10;
                }
                else if (hit.collider.tag == "Hostile")
                {
                    Destroy(hit.collider.gameObject);
                    Score -= 30;
                }
            }
        }
    }

    void Start()
    {
        Score = 0;
    }

    void Update()
    {
        if (time_left.game_time > 0)
        {
            touched();
            if (spawner.spawn)
                Score_Text.text = "SCORE: " + Score.ToString();
        }
        else
            Score_Text.gameObject.SetActive(false);
    }
}