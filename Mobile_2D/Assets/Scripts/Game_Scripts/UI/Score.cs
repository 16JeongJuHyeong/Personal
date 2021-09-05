using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text Score_Text;
    [SerializeField] private Final_Score Final_score;
    public static int score;
    
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        if (Time.timeScale>0f)
            Score_Text.text = "SCORE: " + score.ToString();
        else if ((TimeManager.game_time < 1f))
            this.gameObject.SetActive(false);
    }
}