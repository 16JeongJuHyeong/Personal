using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Bottom_action : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "End_Point")
        {
            Special_Target_Action.InCorner = true;
            Special_Images.Image_Index = 1;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Right")
            Special_Target_Action.Des.x = transform.parent.gameObject.transform.position.x - 0.5f;
        if (other.gameObject.tag == "Bottom")
            Special_Target_Action.Des.y = transform.parent.gameObject.transform.position.y + 0.5f;
    }
    void OnMouseDown()
    {
        if (Special_Target_Action.InCorner)
            StartCoroutine(this.gameObject.transform.parent.GetComponent<Special_Target_Action>().EVENT_());
        else if (!Pause.IsPause)
            Special_Target_Action.Des = transform.parent.gameObject.transform.position + new Vector3(-1.5f, 1.5f, 0);
    }
}