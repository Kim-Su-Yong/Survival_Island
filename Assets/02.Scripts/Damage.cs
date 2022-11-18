using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //씬관련기능

public class Damage : MonoBehaviour
{
    [SerializeField]
    private Image hpBar;
    [SerializeField]
    private Text hpTxt;
    private int hp = 0;
    private int hpMax = 100;
    [SerializeField]
    private GameObject ScreenPanel;
    void Start()
    {                               //오브젝트명으로 찾음
        ScreenPanel = GameObject.Find("Canvas_UI").transform.GetChild(3).gameObject;
        hpBar = GameObject.Find("Panel-HPBar").transform.GetChild(0).GetComponent<Image>();
        //하이라키에서 Panel-HPBar라는 오브젝트명을 찾은 뒤 그하위 첫번째 자식의 이미지 컴퍼넌트
        //를 찾아서 hpBar 이미지를 초기화 시킴
        hpTxt = GameObject.Find("Panel-HPBar").transform.GetChild(1).GetComponent<Text>();
        hp = hpMax;
        hpBar.color = Color.green;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PUNCH")
        {
            HPUIManager();
            if (hp <= 0)
            {
                ScreenPanel.SetActive(true);
                //오브젝트 활성화
                Invoke("PlayerDie", 3.0f);
                //특정함수를 어떤 특정 시간대에 호출 할지 
            }
        }
    }
    void PlayerDie()
    {
        Debug.Log("주인공 사망!!");
        SceneManager.LoadScene("EndScene");
    }
    private void HPUIManager()
    {
        hp -= 15;
        hp = Mathf.Clamp(hp, 0, 100);
        hpBar.fillAmount = (float)hp / (float)hpMax;
        hpTxt.text = hp.ToString() + " / " + hpMax.ToString();
        if (hpBar.fillAmount <= 0.3f)
            hpBar.color = Color.red;
        else if (hpBar.fillAmount <= 0.5f)
            hpBar.color = Color.yellow;
    }
}
