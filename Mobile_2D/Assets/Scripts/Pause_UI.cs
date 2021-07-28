using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_UI : MonoBehaviour
{
    public Pause pause;

    public void Set_Pause()
    {
        if (Pause.pause)
        {
            // 게임 재개 애니메이션 넣기
            pause.GetComponent<Button>().interactable = true;
            transform.parent.gameObject.SetActive(false);
            Pause.pause = false;
            Time.timeScale = 1f;
        }
    }
}
