using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    [SerializeField] private AudioSource UI_Click_Sound;
    [SerializeField] private GameObject Countdown;
    [SerializeField] private GameObject Pause_UI;

    public void Set_Resume()
    {
        UI_Click_Sound.Play();
        Pause_UI.SetActive(false);
        Countdown.SetActive(true);
    }
}