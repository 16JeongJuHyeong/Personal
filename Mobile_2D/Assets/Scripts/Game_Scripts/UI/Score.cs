using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text Score_Text;
    [SerializeField] private Final_Score Final_score;
    public int score;
    
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        if ((Time_Left.game_time > 1f) && !Pause.IsPause)
            Score_Text.text = "SCORE: " + score.ToString();
        else if ((Time_Left.game_time < 1f))
        {
            Final_score.Show_Score();
            this.gameObject.SetActive(false);
        }
    }
}