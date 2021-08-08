using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool IsPause;
    [SerializeField]
    private GameObject Pause_UI;

    void Start()
    {
        IsPause = true;
        GetComponent<Button>().interactable = false;
        Pause_UI.SetActive(false);
    }
    public void Set_Pause()
    {
        GetComponent<Button>().interactable = false;
        Pause_UI.SetActive(true);
        IsPause = true;
    }
}