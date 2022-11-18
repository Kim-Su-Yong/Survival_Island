using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningGun : MonoBehaviour
{
    public Animation Combatani;
    public bool isRunning = false;
    //

    void Start()
    {
        
    }

    void Update()
    {       //만약에 왼쪽쉬프트키와 w키를 둘다 누르는 중이라면
        if (Input.GetKey(KeyCode.LeftShift) &&
            Input.GetKey(KeyCode.W))
        {
            //조건에 맞으면 애니매이션 실행
            Combatani.Play("running");
            isRunning = true;
        }   //또다른 조건 왼쪽 쉬프트키는 땠다면
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Combatani.Play("runStop");
            isRunning = false;
        }
    }
}
