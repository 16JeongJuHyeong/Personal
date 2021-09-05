using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final_Score : MonoBehaviour
{
    [SerializeField] private Text Final_Score_Text;

    void Update()
    {
        Final_Score_Text.text = "SCORE: " + Score.score.ToString();
    }
}