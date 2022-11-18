using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{
    public Light blueLight;
    public Light yellowLight;
    void Start()
    {
        TurnOn();
    }
    void TurnOn()
    {   
        //스타트 코루틴 호출, 원하는 프레임 간격으로 반복 호출
        StartCoroutine(LightOnOff());
    }
    IEnumerator LightOnOff() //시간 간격으로 꺼졌다 켜졌다 반복
    {
        blueLight.enabled = true;
        yellowLight.enabled = false;
        yield return new WaitForSeconds(3.0f);

        //3초가 지난 다음에는 노란색이 켜지고 파란 색은 꺼진다.
        yellowLight.enabled = true;
        blueLight.enabled = false;

        yield return new WaitForSeconds(3.0f);
        //3초동안 유니티는 다른 작업을 하다가 다시 돌아옴
        TurnOn();
    }
}
