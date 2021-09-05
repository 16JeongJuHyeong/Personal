using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] private GameObject Pause_Button;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource Background_Music;
    [SerializeField] private AudioSource Bonus_Music;
    [SerializeField] private AudioSource countdown_sound;

    void Count_Over()
    {
        if (!Background_Music.isPlaying && !TimeManager.IsBonus)
            Background_Music.Play();
        if (!Bonus_Music.isPlaying && TimeManager.IsBonus)
            Bonus_Music.Play();

        Pause_Button.GetComponent<BoxCollider2D>().enabled = true;

        if (!TimeManager.IsBonus)
            TimeManager.time_flow = true;
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
        //TimeManager.IsPause = false;
    }

    void Sound_Effect()
    {
        countdown_sound.Play();
    }
    //애니메이션 이벤트를 사용하면 업데이트로 시간 확인할 필요 없이 알아서 함수를 사용해줌
}