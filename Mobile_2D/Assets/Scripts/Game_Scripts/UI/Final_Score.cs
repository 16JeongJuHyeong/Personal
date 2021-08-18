using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final_Score : MonoBehaviour
{
    [SerializeField] private Text Final_Score_Text;
    [SerializeField] private Score score;

    public void Show_Score()
    {
        Final_Score_Text.text = "SCORE: " + score.score.ToString();
    }

    //void Update()
    //{
    //    Final_Score_Text.text = "SCORE: " + score.score.ToString();
    //}
}