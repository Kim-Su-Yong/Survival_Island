using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject Spark;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip hitSound;
    private readonly string bulletTag = "BULLET";
    void Start()
    {
        source = GetComponent<AudioSource>();
        hitSound = (AudioClip)Resources.Load("Sounds/bullet_hit_metal_enemy_4");
        Spark = (GameObject)Resources.Load("FlareMobile");
    }


    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == bulletTag)
        {
            //Destroy(col.gameObject);
            col.gameObject.SetActive(false);
            source.PlayOneShot(hitSound, 1.0f);
            ShowEffect(col);
        }
        //else if(col.collider.CompareTag(bulletTag2))
        //{
        //    Destroy(col.gameObject);
        //}
    }
    void BulletDeactive(Collision col)
    {
        col.gameObject.SetActive(false);
    }
    private void ShowEffect(Collision col)
    {
        //충돌 지점 좌표를 추출
        ContactPoint contact = col.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, contact.normal);
        //벡터가 이루는 회전 각도를 추출
        GameObject spk = Instantiate(Spark, contact.point, rot);
        Destroy(spk, 2.0f);
    }
}
