using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_Sound : MonoBehaviour
{
    [SerializeField]
    private AudioSource Bonus_Music;
    void Start()
    {
        Bonus_Music.Pause();
    }
}
