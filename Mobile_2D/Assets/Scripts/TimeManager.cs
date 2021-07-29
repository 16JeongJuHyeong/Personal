using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static int time_flow;

    void Awake()
    {
        time_flow = 1;
    }
}