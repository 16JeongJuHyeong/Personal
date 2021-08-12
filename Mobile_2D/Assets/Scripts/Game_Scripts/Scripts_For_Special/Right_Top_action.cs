using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Top_action : MonoBehaviour //상속받을 클래스 이름 기입
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pause_UI")
            StartCoroutine(this.gameObject.transform.parent.GetComponent<Special_Target_Action>().PAUSE_EVENT(other.gameObject));
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Right")
            Special_Target_Action.Des.x = transform.parent.gameObject.transform.position.x - 0.5f;
        if (other.gameObject.tag == "Top")
            Special_Target_Action.Des.y = transform.parent.gameObject.transform.position.y - 0.5f;
    }

    void OnMouseDown()
    {
        if (!Pause.IsPause && TimeManager.time_flow)
        {
            Special_Target_Action.Image_Index = Random.Range(2, 4);
            Special_Target_Action.Des = transform.parent.gameObject.transform.position + new Vector3(-1.5f, -1.5f, 0);
        }
    }
}