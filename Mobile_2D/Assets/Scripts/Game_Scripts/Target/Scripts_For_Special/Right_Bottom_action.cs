using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Bottom_action : Special_Collider_Action
{
    protected override void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Right")
            Special_Target_Action.Des.x = transform.parent.gameObject.transform.position.x - Reverse_Distance;
        if (other.gameObject.tag == "Bottom")
            Special_Target_Action.Des.y = transform.parent.gameObject.transform.position.y + Reverse_Distance;
    }
    protected override void OnMouseDown()
    {
        if (TimeManager.time_flow && Time.timeScale > 0f)
        {
            Clicked_Sound.Play();
            Special_Target_Action.Des = transform.parent.gameObject.transform.position + To_Left_Top;
        }
    }
}