using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : MonoBehaviour
{
    private bool IsFalling;
    public bool ToLeft;
    [SerializeField]
    private GameObject Special_Target;
    Vector2 spawn_position = new Vector2(1, 1);

    void Start()
    {
        IsFalling = false;
        ToLeft = true;
        //spawn_position에 오브젝트 위치 설정할것
        StartCoroutine(Falling_Start());
    }

    void Updata()
    {
        if (IsFalling)
        {
            Falling_Direction(); //떨어지는 동안 방향 설정
            Catch(); //떨어지는 동안은 잡을 수 있어야 하니까
        }
    }

    IEnumerator Falling_Start() // 떨어지는 기능
    {
        yield return new WaitForSeconds(20f);  //시작하고 20초 뒤 생성
        Instantiate(Special_Target,spawn_position, Quaternion.Euler(0, 0, 0) ); // 오브젝트 복제 후 낙하
        IsFalling = true;
    }

    void Falling_Direction()
    {
        //if(ToLeft)
        //    transform.position.x -= Time.deltaTime;
        //else
        //    transform.position.x += Time.deltaTime;
        //떨어질 때 방향 설정하기
        //에러 있음
    }

    void Catch()
    {

    }


}
