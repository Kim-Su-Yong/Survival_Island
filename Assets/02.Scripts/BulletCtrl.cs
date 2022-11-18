using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    [SerializeField]    //어트리뷰트 속성
    private Rigidbody rbody;
    public float Speed = 1000f;
    void Start()
    {   //시작 전 스타트 함수 rbody 초기화
        rbody = GetComponent<Rigidbody>();
        rbody.AddForce(transform.forward * Speed);
        //방향과 속력 = velocity
        Destroy(gameObject, 3f);
        //자기 자신의 오브젝트가 3초후에 사라짐
    }
}
