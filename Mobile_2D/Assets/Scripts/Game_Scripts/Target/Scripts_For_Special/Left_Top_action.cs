using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_Top_action : Special_Collider_Action
{
    protected override void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Left")
            Special_Target_Action.Des.x = Special.position.x + Reverse_Distance;
        if (other.gameObject.tag == "Top")
            Special_Target_Action.Des.y = Special.position.y - Reverse_Distance;
    }
    protected override void OnMouseDown()
    {
        if (TimeManager.time_flow && Time.timeScale > 0f)
        {
            Clicked_Sound.Play();
            Special_Target_Action.Des = Special.position + To_Right_Bottom;
        }
    }
}