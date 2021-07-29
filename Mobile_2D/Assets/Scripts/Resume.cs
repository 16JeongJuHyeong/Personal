using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    public Countdown timer;
    [SerializeField]
    private GameObject Pause_Button;

    public void Set_Resume()
    {
        Pause_Button.GetComponent<Button>().interactable = true;
        this.transform.parent.gameObject.SetActive(false);
        timer.gameObject.SetActive(true);
        timer.count_ready = true;
    }
}
