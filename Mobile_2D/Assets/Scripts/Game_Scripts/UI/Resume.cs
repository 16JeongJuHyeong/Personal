using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    [SerializeField] private AudioSource UI_Click_Sound;
    [SerializeField] private GameObject Countdown;

    public void Set_Resume()
    {
        UI_Click_Sound.Play();
        this.transform.parent.gameObject.SetActive(false);
        Countdown.SetActive(true);
    }
}