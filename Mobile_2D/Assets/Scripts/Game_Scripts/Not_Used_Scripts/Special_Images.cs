using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Images : MonoBehaviour
{
    public SpriteRenderer Special_Sprite;
    public Sprite[] Monkey_Images;
    public static int Image_Index;
    public float vib_intensity;

    void Start()
    {
        Image_Index = 0;
    }
    //외부에서 Special sprite 바꿔주기
    void Update()
    {
        Special_Sprite.sprite = Monkey_Images[Image_Index];
        if (!Pause.IsPause)
        {
            if (Special_Sprite.sprite == Monkey_Images[0])
                Idle();
            else if (Special_Sprite.sprite == Monkey_Images[1])
                InPanic();
        }
    }
    void Idle()
    {
        //약간의 흔들림
    }


    void InPanic()
    {
        //진동
        transform.position += Random.insideUnitSphere * vib_intensity;
    }





}