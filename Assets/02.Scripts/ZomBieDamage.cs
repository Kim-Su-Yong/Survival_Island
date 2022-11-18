using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZomBieDamage : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField] // 개발할때는 다 보이게 적어두고 출시앞두고는 다 지움
    private Animator animator;
    public GameObject BloodEffect;
    private float hp = 0;
    private float hpMax = 100f;
    public bool IsDie = false;
    public Image hpBar;
    public Canvas hpCanvas;
    public AudioSource source;
    public AudioClip OnSound;
    ZombieCtrl zombieCtrl;
    void Start()
    {
        zombieCtrl = GetComponent<ZombieCtrl>();
        //자기자신 컴포넌트의 네비를 agent로 넘김
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        hp = hpMax;
        hpBar.color = Color.green;
    }
    private void OnCollisionEnter(Collision col)
    {   //충돌체의 태그 검사
        if(col.gameObject.tag == "BULLET")
        {
            HitAniEffect(col);
            hp -= 25;
            hpBar.fillAmount = (float)hp / (float)hpMax;
            if (hpBar.fillAmount <= 0.25f)
                hpBar.color = Color.red;
            else if (hpBar.fillAmount <= 0.5f)
                hpBar.color = Color.yellow;

            if (hp <= 0)
                Die();
        }
    }
    void Die()
    {
        animator.SetTrigger("IsDie");
        IsDie = true;
        hpCanvas.enabled = false;
        source.PlayOneShot(OnSound, 1.0f);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<CapsuleCollider>().enabled = false;
        //사망했을 때 캡슐콜라이더 비활성화
        G_Manager.g_manager.KillCount(1);
        //Destroy(this.gameObject, 1.0f);
        //자기자신 오브젝트 하위에 스피어 콜라이더
        StartCoroutine(PushPool());
    }
    IEnumerator PushPool()
    {
        yield return new WaitForSeconds(3.0f);

        this.gameObject.SetActive(false);
        IsDie = false;
        hpCanvas.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<CapsuleCollider>().enabled = true;
        hp = 100f;
    }
    private void HitAniEffect(Collision col)
    {
        Destroy(col.gameObject);
        agent.isStopped = true;
        animator.SetTrigger("IsHit");               //충돌 위치
        GameObject blood = Instantiate(BloodEffect, col.transform.position, Quaternion.identity); //BloodEffect 생성시 회전하지 않음
        Destroy(blood, 1.0f);
    }
}
