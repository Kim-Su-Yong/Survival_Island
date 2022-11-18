using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    public Light inLight;
    public AudioSource source;
    public AudioClip OnSound;
    public AudioClip OffSound;
    //isTrigger 체크시 통과하면서 충돌 감지 할때 쓰이는 CallBack 함수 유니티에서 지원 스스로 호출
    private void OnTriggerEnter(Collider other)
    {   //만약에 충돌한 태그가 Player 같다면 
        if(other.gameObject.tag == "Player")
        {
            inLight.enabled = true;
            //라이트 켠다
            source.PlayOneShot(OnSound, 1.0f);
            //소리가 울린다. 무엇을    ,볼륨 값

        }
    }

    private void OnTriggerExit(Collider other)
    {   //만약에 충돌한 태그가 Player 같다면 
        if (other.gameObject.tag == "Player")
        {
            inLight.enabled = false;
            //라이트 켠다
            source.PlayOneShot(OffSound, 1.0f);
            //소리가 울린다. 무엇을    ,볼륨 값

        }
    }

}
