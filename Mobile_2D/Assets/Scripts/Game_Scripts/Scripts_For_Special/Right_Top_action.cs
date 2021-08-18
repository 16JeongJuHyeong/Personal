using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Top_action : Special_Collider_Action
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pause")
            StartCoroutine(this.gameObject.transform.parent.GetComponent<Special_Target_Action>().PAUSE_EVENT(other.gameObject));
    }

    protected override void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Right")
            Special_Target_Action.Des.x = transform.parent.gameObject.transform.position.x - Reverse_Distance;
        if (other.gameObject.tag == "Top")
            Special_Target_Action.Des.y = transform.parent.gameObject.transform.position.y - Reverse_Distance;
    }

    protected override void OnMouseDown()
    {
        Clicked_Sound.Play();
        if (!Pause.IsPause && TimeManager.time_flow)
            Special_Target_Action.Des = transform.parent.gameObject.transform.position + To_Left_Bottom;
    }
}