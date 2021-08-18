using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby_Text : MonoBehaviour
{
    [SerializeField]
    private Text lobby_text;

    void Start()
    {
        StartCoroutine(Text_Size_Up());
    }

    IEnumerator Text_Size_Up()
    {
        yield return new WaitForSeconds(0.05f);
        lobby_text.fontSize += 1;
        if (lobby_text.fontSize == 50)
            StartCoroutine(Text_Size_Down());
        else
            StartCoroutine(Text_Size_Up());
    }
    IEnumerator Text_Size_Down()
    {
        yield return new WaitForSeconds(0.05f);
        lobby_text.fontSize -= 1;
        if (lobby_text.fontSize == 40)
            StartCoroutine(Text_Size_Up());
        else
            StartCoroutine(Text_Size_Down());
    }
}


//*lobby_text.color = new Color(1, 1, 1, 1 - time);
//*Color(R,G,B,밝기) 인거 같음