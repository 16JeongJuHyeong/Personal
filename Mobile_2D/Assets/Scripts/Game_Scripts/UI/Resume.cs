using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    public Countdown timer;

    public void Set_Resume()
    {
        this.transform.parent.gameObject.SetActive(false);
        timer.gameObject.SetActive(true);
        timer.count_ready = true;
    }
}