using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Sound : MonoBehaviour
{
    [SerializeField] private AudioSource Sound;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            if(TimeManager.time_flow && Time.timeScale > 0f)
                Sound.Play();
    }
}