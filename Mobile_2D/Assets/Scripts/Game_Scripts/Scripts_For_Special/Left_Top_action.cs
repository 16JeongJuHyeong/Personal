﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_Top_action : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.tag == "Left")
                Special_Target_action2.Des.x = transform.parent.gameObject.transform.position.x + 0.5f;
            if (other.gameObject.tag == "Top")
                Special_Target_action2.Des.y = transform.parent.gameObject.transform.position.y - 0.5f;
    }
    void OnMouseDown()
    {
        if(!Pause.IsPause)
            Special_Target_action2.Des = transform.parent.gameObject.transform.position + new Vector3(1.5f, -1.5f, 0);
    }
}