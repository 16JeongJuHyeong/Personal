using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text Score_Text;

    public int score;
    
    void Start()
    {
        this.gameObject.SetActive(true);
        score = 0;
    }

    void Update()
    {
        if (Spawner.spawn || Spawner.IsBonus)
            Score_Text.text = "SCORE: " + score.ToString();
        else if(Time_Left.game_time < 0)
            this.gameObject.SetActive(false);
    }
}