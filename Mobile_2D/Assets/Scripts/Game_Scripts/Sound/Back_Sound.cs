using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_Sound : MonoBehaviour
{
    [SerializeField]
    private AudioSource Background_Music;
    void Start()
    {
        Background_Music.Pause();
    }
}
