using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostile_Text : MonoBehaviour
{
    [SerializeField] private MeshRenderer Mesh_Text;
    private GameObject Special;

    void Update()
    {
        Special = GameObject.Find("Special(Clone)");
        if (Special != null)
            Show_Text();
        else
            Hide_Text();
    }

    public void Show_Text()
    {
        Mesh_Text.enabled = true;
    }
    public void Hide_Text()
    {
        Mesh_Text.enabled = false;
    }
}


//대체로 Find, GetComponent가 비용이 많이 든다
//꼭 써야 한다면 캐싱 하고 쓰는게 좋음
//지금 상황은 이 객체는 Special보다 먼저 나오고, 메시지는 Special이 있을 때만 출력되어야 함
//캐싱 하려면 Start,Awake 등에서 먼저 초기화 해야하는데 Special이 없을 때 수행하면 그냥 null임
//이후 Special이 등장해도 이전에 캐싱했으므로 null이고, Update함수는 null만 받기 때문에 원하는 내용 수행 어려움
//그래서 어쩔 수 없이 Find 를 Update에 사용했음