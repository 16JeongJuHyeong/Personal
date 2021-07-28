using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//시작될 때 + 게임 재개할 때 실행되게 하기


public class Countdown : MonoBehaviour
{
    //private float anim_time;

    //void count_check()
    //{
    //    
    //    anim_time -= Time.deltaTime;
    //    if (anim_time < 0)
    //    {
    //        Spawner.spawn = true;
    //        this.gameObject.SetActive(false);
    //    }
    //}

    void Start()
    {
        Animator anim = this.gameObject.GetComponent<Animator>();
        anim.Play("Countdown");
        Spawner.spawn = true;
        //anim_time = 3f;
    }

    //void Update()
    //{
    //    count_check();
    //}

}
