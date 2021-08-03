using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_Bottom_action : Special_Target_action2
{
    protected override void OnMouseDown()
    {
        Des = transform.parent.gameObject.transform.position + new Vector3(0.3f, 0.3f, 0);
        Debug.Log(Des);
        //New_Des = transform.parent.gameObject.transform.position + new Vector3(0.3f,0.3f,0);
    }
}