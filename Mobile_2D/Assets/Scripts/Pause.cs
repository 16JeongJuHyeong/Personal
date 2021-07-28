using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool pause;

    [SerializeField]
    private GameObject Pause_UI;
    public void Set_Pause()
    {
        if(!pause)
        {
            GetComponent<Button>().interactable = false;
            Pause_UI.SetActive(true);
            pause = true;
            Time.timeScale = 0f;
        }
    }
    void Start()
    {
        pause = false;
        Pause_UI.SetActive(false);
    }

    void Update()
    {
        
    }
}
