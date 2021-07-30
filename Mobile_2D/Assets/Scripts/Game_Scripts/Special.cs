using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : MonoBehaviour
{
    private SpriteRenderer target_body;

    float x_direction;
    float y_direction;

    void Start()
    {
        target_body = this.gameObject.GetComponent<SpriteRenderer>(); 
        x_direction = Random.Range(-1.5f, 1.5f);
        y_direction = Random.Range(-1.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target_body.isVisible)
            transform.position = transform.position + new Vector3(x_direction, y_direction, 0) * 0.004f;
        else
            Destroy(this.gameObject);
    }
}
