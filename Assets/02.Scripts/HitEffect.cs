using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//1.충돌 감지 총알은 맞자마자 사라지고 이펙트효과 나고 소리도 난다.

public class HitEffect : MonoBehaviour
{
    public GameObject Spark;
    public AudioSource source;
    public AudioClip hitSound;

    //isTrigger 체크 안했을 때 충돌 감지하는 함수 콜백 함수 block 막한다.
    private void OnCollisionEnter(Collision col)
    {   //태그 검사
        if(col.gameObject.tag == "BULLET")
        {
            Destroy(col.gameObject);
            source.PlayOneShot(hitSound, 1.0f);
            GameObject eff = Instantiate(Spark, col.transform.position, Quaternion.identity);
            Destroy(eff, 2.5f);
        }
    }
}
