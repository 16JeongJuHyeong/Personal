using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    public void ReStart()
    {
        TimeManager.time_flow = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex): 새로 불러오기
    }
}