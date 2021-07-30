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
        GetComponent<Button>().interactable = false;
        Pause_UI.SetActive(false);
    }
    public void Set_Pause()
    {
        GetComponent<Button>().interactable = false;
        Pause_UI.SetActive(true);
        TimeManager.time_flow = 0;
        Spawner.spawn = false;  //타임매니저의 타임플로우를 Spawner에서 코루틴 함수에 사용해도 되긴 함
    }
}