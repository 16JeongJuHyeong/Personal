using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby_Text : MonoBehaviour
{
    const int font_ = 1;
    const int Max_fontSize = 60;
    const int Min_fontSize = 40;
    [SerializeField]
    private Text Touch_Text;

    private bool Text_Size_Up;

    void Start()
    {
        Text_Size_Up = true;
        StartCoroutine(Text_Size_Increase());
        StartCoroutine(Text_Size_Decrease());
    }

    void Update()
    {
        if (Touch_Text.fontSize > Max_fontSize)
            Text_Size_Up = false;
        else if(Touch_Text.fontSize < Min_fontSize)
            Text_Size_Up = true;
    }

    IEnumerator Text_Size_Increase()
    {
        WaitForSeconds wait = new WaitForSeconds(0.015f);
        while(true)
        {
            if (Text_Size_Up)
                Touch_Text.fontSize += font_;
            yield return wait;
        }
    }

    IEnumerator Text_Size_Decrease()
    {
        WaitForSeconds wait = new WaitForSeconds(0.03f);
        while(true)
        {
            if (!Text_Size_Up)
                Touch_Text.fontSize -= font_;
            yield return wait;
        }
    }
}


//*lobby_text.color = new Color(1, 1, 1, 1 - time);
//*Color(R,G,B,밝기) 인거 같음