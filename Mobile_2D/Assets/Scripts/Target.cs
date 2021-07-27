using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Time_Left time_left;

    float x_direction;
    float y_direction;
    void Start()
    {
        time_left = GameObject.Find("Time").GetComponent<Time_Left>();

        x_direction = Random.Range(-1.5f, 1.5f);
        y_direction = Random.Range(-1.5f, 1.5f);
    }

    void moving()
    {
        if ( (transform.position.x > -2 && transform.position.x < 2) || transform.position.y > -2 && transform.position.y < 2)
            transform.position = transform.position + new Vector3(x_direction, y_direction, 0) * 0.002f;
        else
            Destroy(this.gameObject);
    }

    void Update()
    {
        if (time_left.game_time > 0)
            moving();
        else
            Destroy(this.gameObject);
    }

}

