using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLobby : MonoBehaviour
{
    [SerializeField] private AudioSource UI_Click_Sound;
    public void Load_Lobby()
    {
        Time.timeScale = 1f;
        UI_Click_Sound.Play();
        SceneManager.LoadScene("Lobby");  // *SceneManager.LoadScene("씬 이름") : 씬을 불러옴
    }
}