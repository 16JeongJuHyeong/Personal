using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public AudioSource Game_Over_Sound;
    void Start()
    {
        Game_Over_Sound.Play();
    }
}
