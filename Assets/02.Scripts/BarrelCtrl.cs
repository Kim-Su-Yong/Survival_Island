using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    public Texture[] textures;
    [SerializeField]
    private MeshRenderer renderers;
    [SerializeField]
    private GameObject ExplosionEffect;
    public int hitCount = 0;
    private AudioSource _audio;
    [SerializeField]
    private AudioClip expSound;
    [SerializeField]
    CameraShake shake;
    void Start()
    {
        shake = Camera.main.GetComponent<CameraShake>();
        _audio = GetComponent<AudioSource>();
        renderers = GetComponent<MeshRenderer>();
        textures = Resources.LoadAll<Texture>("BarrelTexture");
        ExplosionEffect = Resources.Load<GameObject>("Effects/BigExplosionEffect");
        expSound = Resources.Load<AudioClip>("Sounds/missile_explosion");
        int idx = Random.Range(0, textures.Length);
        renderers.material.mainTexture = textures[idx];
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.CompareTag("BULLET"))
        {
            if(++hitCount == 3)
            {
                BarrelExplosion();
            }
        }
    }
    void BarrelExplosion() //배럴 폭파 함수
    {
        GameObject exp = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(exp, 1.0f);
        _audio.PlayOneShot(expSound, 1.0f);
        Collider[] Cols = Physics.OverlapSphere(transform.position, 20f);
                            //20근방에 오브젝트에서 충돌체가 있으면 Cols라는 배열에 대입이 된다.
        foreach(Collider col in Cols)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();
            if(rb != null)
            {
                if (col.gameObject.tag != "Player")
                {
                    rb.mass = 1.0f; //리지디 바디의 무게를 1로 만듬 높이 날아가기 위해
                    rb.AddExplosionForce(1200f, transform.position, 20, 1000f);
                    //폭파함수        //폭파력, 위치, 반경, 위로 솟구치는 힘
                    col.gameObject.SendMessage("IsDie", SendMessageOptions.DontRequireReceiver);
                    //다른 오브젝트에 있는 함수를 호출 할 수 있는 함수
                    //SendMessageOptions.DontRequireReceiver 함수가 없거나 오타가 있어도
                    //오류를 내지 않게 하는 옵션이다.
                }
            }
           
        }
        StartCoroutine(shake.ShakeCamera(0.8f, 0.5f, 0.7f));
    }
}
