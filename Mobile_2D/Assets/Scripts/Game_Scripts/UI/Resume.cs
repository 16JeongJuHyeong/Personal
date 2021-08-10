using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    public Countdown Timer;
    public void Set_Resume()
    {
        this.transform.parent.gameObject.SetActive(false);
        Timer.gameObject.SetActive(true);
    }
}