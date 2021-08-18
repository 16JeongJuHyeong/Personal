using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostile_Text : MonoBehaviour
{
    [SerializeField] private MeshRenderer Mesh_Text;
    public Special_Target_Action Special;

    void Start()
    {
        Special = GameObject.Find("Special(Clone)").GetComponent<Special_Target_Action>();
    }

    void Update()
    {
        if (Special == null)
            return;
        else
        {
            Special.Special_Alert(this);
            if (Special.NotInAction) //두번째 주석에 설명
                Mesh_Text.enabled = true;
            else
                Mesh_Text.enabled = false;
        }
    }

    public void Hostile_Alert(Special_Target_Action special_)
    {
        Special = special_;
    }
}

//*Awake는 스크립트가 비활성화되어도 작용됨
//Start보다 먼저 실행되므로
//*인스펙터 내 요소들이 비활성화되어 있어도 게임 자체적으로 적용


//대체로 Find, GetComponent가 비용이 많이 든다(유니티 홈페이지 출처)
//꼭 써야 한다면 캐싱 하고 쓰는게 좋음
//지금 상황은 이 객체는 Special보다 먼저 나오고, 메시지는 Special이 있을 때만 출력되어야 함
//캐싱 하려면 Start,Awake 등에서 먼저 초기화 해야하는데 Special이 없을 때 수행하면 그냥 null임
//이후 Special이 등장해도 이전에 캐싱했으므로 null이고, Update함수는 null만 받기 때문에 원하는 내용 수행 어려움