using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject Pause_UI;

    void Start()
    {
        Pause_UI.SetActive(false);
    }
    public void Set_Pause()
    {
        GetComponent<Button>().interactable = false;
        Pause_UI.SetActive(true);
        Time.timeScale = 0f;
    }
}