using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject Pause_UI;
    [SerializeField] private AudioSource Background_Music;
    [SerializeField] private AudioSource Bonus_Music;

    public bool drop;
    private SpriteRenderer check_pause;

    const float drop_speed = 0.07f;
    const float rotate_speed = 1f;

    void Start()
    {
        check_pause = GetComponent<SpriteRenderer>(); //처음 생성 시 SpriteRenderer.isVisible은 false
        drop = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Pause_UI.SetActive(false);
    }

    void OnMouseDown()
    {
        if (Background_Music.isPlaying && Time.timeScale > 0f)
            Background_Music.Pause();
        if (Bonus_Music.isPlaying && TimeManager.IsBonus)
            Bonus_Music.Pause();

        Time.timeScale= 0f;
        GetComponent<BoxCollider2D>().enabled = false;
        Pause_UI.SetActive(true);
        //TimeManager.IsPause = true;
    }

    void Update()
    {
        if (drop)
        {
            if (check_pause.isVisible)
            {
                transform.Rotate(0, 0, rotate_speed);
                transform.position += Vector3.down * drop_speed;
                // 떨어지는 건 rigidbody2D에서 중력설정해도 괜찮음
            }
            else
                Destroy(this.gameObject);
        }
        if (TimeManager.game_time < 1f)
            this.gameObject.SetActive(false);
    }
}