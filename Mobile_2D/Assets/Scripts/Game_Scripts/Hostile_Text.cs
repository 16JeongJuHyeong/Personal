using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostile_Text : MonoBehaviour
{
    void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
    void Update()
    {
        if (GameObject.Find("Special(Clone)") != null)
        {
            if (GameObject.Find("Special(Clone)").GetComponent<Special_Target_Action>().NotInAction)
                GetComponent<MeshRenderer>().enabled = true;
            else
                this.gameObject.SetActive(false);
        }
    }
}
//*Awake는 스크립트가 비활성화되어도 작용됨
//Start보다 먼저 실행되므로
//*인스펙터 내 요소들이 비활성화되어 있어도 게임 자체적으로 적용