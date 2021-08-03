using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Top_action : Special_Target_action2 //상속받을 클래스 이름 기입
{
    protected override void OnMouseDown()
    {
        Des = transform.parent.gameObject.transform.position + new Vector3(-0.3f, -0.3f, 0);

        //New_Des = transform.parent.gameObject.transform.position + new Vector3(0.3f,0.3f,0);
    }
}