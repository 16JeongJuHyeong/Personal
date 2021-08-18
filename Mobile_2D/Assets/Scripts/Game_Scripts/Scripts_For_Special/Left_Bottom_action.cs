using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_Bottom_action : Special_Collider_Action
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Blackhole")
            StartCoroutine(this.gameObject.transform.parent.GetComponent<Special_Target_Action>().BONUS_EVENT());
    }
    protected override void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Left")
            Special_Target_Action.Des.x = transform.parent.gameObject.transform.position.x + Reverse_Distance;
        if (other.gameObject.tag == "Bottom")
            Special_Target_Action.Des.y = transform.parent.gameObject.transform.position.y + Reverse_Distance;
    }
    protected override void OnMouseDown()
    {
        Clicked_Sound.Play();
        if (!Pause.IsPause && TimeManager.time_flow)
            Special_Target_Action.Des = transform.parent.gameObject.transform.position + To_Right_Top;
    }
}