using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
//1.총알 2.애니메이션 동작 3.발사위치
public class FireCtrl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Animation combatani;
    public Transform firePos;
    public AudioSource source;
    public AudioClip bulletSound;
    [SerializeField] //runGun이 보이게 함
    private RunningGun runGun;
    [SerializeField]
    private WeaponChange weaponChange;
    public Light FlashLight;
    public AudioClip flashSound;
    public int bulletCount = 0;
    public bool isreload = false;
    //클래스명 클래스변수
    void Start()
    {           //자기자신 오브젝트에 있는 RunningGun 스크립트로 초기화 한다
        runGun = GetComponent<RunningGun>();
        weaponChange = GetComponent<WeaponChange>();
    }


    void Update()
    {   //마우스 왼쪽 버튼을 눌렀다면 1.오른쪽 2.휠버튼
        if (Input.GetMouseButtonDown(0))
        {
            if (runGun.isRunning == false)
            {
                if (weaponChange.isHavM4A1 == true)
                    StartCoroutine(FastBulletFire());
                else
                    Fire();
            }

        }
        FlashOnOff();
        Reloading();
    }

    private void Reloading()
    {
        if (bulletCount == 10)
        {
            isreload = true;
            StartCoroutine(ReloadDeley());
            //협력 루틴
            //프레임을 개발자가 조정하기 위해 사용
            bulletCount = 0;
        }
    }
    IEnumerator ReloadDeley()
    {
        yield return new WaitForSeconds(0.1f);
        combatani.Stop("fire");
        combatani.CrossFade("pump2", 0.3f);
        //앞전 애니메이션 동작과 지금 하려는 동작 애니메이션을 0.3초간 겹치게 해서
        //부드러운 애니메이션 즉 블렌드 애니메이션을 만들기 위해서
        yield return new WaitForSeconds(0.5f);
        isreload = false;
    }
    private void FlashOnOff()
    {
        if (Input.GetKeyDown(KeyCode.F)) //F키를 눌렀다면
        {
            FlashLight.enabled = !FlashLight.enabled;
            source.PlayOneShot(flashSound, 1.0f);
        }
    }
    void Fire()
    {
        if (isreload == false)
        {
            //what?         , where?          , how rotation
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
            //프리팹 생성 함수
            //GameObject _bullet = G_Manager.g_manager.GetBullet();
            //if (_bullet != null)
            //{
            //    _bullet.transform.position = firePos.position;
            //    _bullet.transform.rotation = firePos.rotation;
            //    _bullet.SetActive(true);
            //}
            combatani.Play("fire");
            source.PlayOneShot(bulletSound, 1.0f);
            ++bulletCount;
        }
    }
    IEnumerator FastBulletFire()
    {
        if (isreload == false)
        {
            Fire();
            yield return new WaitForSeconds(0.2f);
            Fire();
            yield return new WaitForSeconds(0.2f);
            Fire();
        }
    }
}
