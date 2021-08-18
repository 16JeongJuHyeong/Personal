using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    [SerializeField] private AudioSource UI_Click_Sound;
    public void ReStart()
    {
        UI_Click_Sound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex): 새로 불러오기
    }
}