using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField]
    private Text killTxt;
    void Start()
    {
        killTxt = GameObject.Find("Background").transform.GetChild(0).GetComponent<Text>();
        killTxt.text = "Kill : " +"<color=#ff0000>"+G_Manager.total.ToString()+"</color>";
    }

}
