using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Target_action1 : MonoBehaviour
{
    private bool IsFalling;
    private bool ToLeft;
    void Start()
    {
        IsFalling = false;
        ToLeft = true;
        StartCoroutine(Fall());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            ToLeft = !ToLeft;
        if (IsFalling)
            Falling_Direction();
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(5f);
        IsFalling = true;
    }

    void Falling_Direction()
    {
        if (ToLeft)
            transform.position -= new Vector3(0.002f, 0.002f, 0);
        else
            transform.position += new Vector3(0.002f, (-0.002f), 0);
    }
}