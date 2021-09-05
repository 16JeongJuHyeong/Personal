using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_images : MonoBehaviour
{
    SpriteRenderer image;
    public Sprite[] trash_images;
    private int arr_idx;

    void Start()
    {
        arr_idx = Random.Range(0, trash_images.Length);
        image = GetComponent<SpriteRenderer>();
        image.sprite = trash_images[arr_idx];
    }
}
//*실수한 부분 : 위에서 public으로 sprite를 선언 후 inspector에 가져다 쓰면
//아래에 new 할 필요가 없다->배열을 새로 선언하는 꼴로, 초기화시켜버림