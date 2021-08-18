using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool IsPause;

    [SerializeField] private GameObject Pause_UI;
    [SerializeField] private AudioSource Background_Music;
    [SerializeField] private AudioSource Bonus_Music;

    public bool drop;
    private SpriteRenderer check_pause;

    const float drop_speed = 0.1f;
    const float rotate_speed = 1f;

    void Start()
    {
        check_pause = GetComponent<SpriteRenderer>(); //처음 생성 시 SpriteRenderer.isVisible은 false
        drop = false;
        IsPause = true;
        GetComponent<BoxCollider2D>().enabled = false;
        Pause_UI.SetActive(false);
    }

    void OnMouseDown()
    {
        if (Background_Music.isPlaying && !IsPause)
            Background_Music.Pause();
        if (Bonus_Music.isPlaying && Spawner.IsBonus)
            Bonus_Music.Pause();
        GetComponent<BoxCollider2D>().enabled = false;
        Pause_UI.SetActive(true);
        IsPause = true;
    }

    void Update()
    {
        if (drop)
        {
            if (check_pause.isVisible)
            {
                transform.Rotate(0, 0, rotate_speed);
                transform.position += Vector3.down * drop_speed;
            }
            else
                Destroy(this.gameObject);
        }
        if (Time_Left.game_time < 1f)
            this.gameObject.SetActive(false);
    }
}