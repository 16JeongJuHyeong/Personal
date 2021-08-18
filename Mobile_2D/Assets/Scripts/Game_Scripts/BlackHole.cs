using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    const float Rotate_speed = 0.05f;
    void Update()
    {
        if (Time_Left.game_time < 1f)
            Destroy(this.gameObject);
        else
            transform.Rotate(0, 0, Rotate_speed);
    }
}