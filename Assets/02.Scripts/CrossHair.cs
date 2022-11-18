using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Eyecast라는 클래스 : 광선을 쏘아서 충돌감지 하면
//여기에서는(CrossHair) 이미지 조준점이 적을 겨눌때 커지거나 색깔이 변하는 기능을
//구현한다.
public class CrossHair : MonoBehaviour
{
    [SerializeField]
    Transform tr;
    [SerializeField]
    private Image crosshair;
    private float startTime;
    //크로스헤어 이미지가 커지기 시작하는 시각을 저장할 변수
    public float duration = 0.2f; //커지는 속도
    public float minSize = 0.1f;
    public float maxSize = 0.3f;
    //초기 색상 R,G,B,Alpha(투명도)
    private Color originColor = new Color(1f, 1f, 0f, 0.8f);
    public Color gazeColor = Color.red; //응시중일때 컬러
    public bool isGaze = false; //응시중이냐 아니냐 판단
    public static CrossHair _crosshair; //클래스 명 클래스 변수
           //전역 변수
    void Start()
    {
        tr = GetComponent<Transform>();
        crosshair = GetComponent<Image>();
        startTime = Time.time; //과거시를 만들기 위해
        tr.localScale = Vector3.one * minSize;
        //xyz 좌표로 동일한 크기를 가지기 위해
        crosshair.color = originColor;
        _crosshair = this;
    }

    void Update()
    {
        if (isGaze) //응시중이라면
        {
            float t = (Time.time - startTime) / duration;
            //지나간 시간에서 0.2로 나눈다. //수학공식 보간하는 함수
            tr.localScale = Vector3.one * Mathf.Lerp(minSize, maxSize, t);
            //크로스 헤어서 min사이즈에서 max사이즈로 변경될때 동일한 좌표 비율로 커지고
            //원래 크기에서 커질때 부드럽게 보간함수를 이동해서 커진다.
            crosshair.color = gazeColor;
        }
        else //응시중이 아니면
        {
            tr.localScale = Vector3.one * minSize; //원래 사이즈로 바꿈
            crosshair.color = originColor; //원래 색상으로
            startTime = Time.time; //과거시로 만든다.
        }
    }
}
