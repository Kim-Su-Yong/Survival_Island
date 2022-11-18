using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeCast : MonoBehaviour
{
    Transform tr;
    Ray ray; //광선 자료형 Ray ray //광선 자료형의 변수
    RaycastHit hit; //광선이 특정 오브젝트에 닿았는지 충돌 감지해주는 자료형
    public float dist = 15f; //광선 감지 범위
                 //거리

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {         //새로메모리 할당
        ray = new Ray(tr.position,tr.forward * dist);
        //위치 origin, 방향 direction * 거리
        Debug.DrawRay(ray.origin, ray.direction * dist, Color.green);
            //광선에 맞았다면 좀비나 스켈레톤이 
        if(Physics.Raycast(ray,out hit,dist,1<<8 | 1<<9 | 1<<10))
        {
            CrossHair._crosshair.isGaze = true;
        }
        else //광선에 맞지 않았다면
        {
            CrossHair._crosshair.isGaze = false;
        }
    }
}
