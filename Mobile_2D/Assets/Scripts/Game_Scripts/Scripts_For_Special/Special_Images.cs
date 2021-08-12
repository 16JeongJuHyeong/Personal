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

    }


    void InPanic()
    {//약간 흔들거리는 효과
        transform.position += Random.insideUnitSphere * vib_intensity;
    }





}