using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public SkinnedMeshRenderer Spas12;
    public MeshRenderer[] Ak47;
    public MeshRenderer[] M4A1;
    public Animation animation;
    public bool isHavM4A1 = false;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            isHavM4A1 = false;
            animation.Play("draw");
            for(int i = 0; i < Ak47.Length; i++)
            {
                Ak47[i].enabled = true;
                //메쉬렌더러 활성화
            }
            Spas12.enabled = false;
            for(int i =0; i<M4A1.Length;i++)
            {
                M4A1[i].enabled = false;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            isHavM4A1 = false;
            animation.Play("draw");
            for (int i = 0; i < Ak47.Length; i++)
            {
                Ak47[i].enabled = false;
                //메쉬렌더러 활성화
            }
            Spas12.enabled = true;
            for (int i = 0; i < M4A1.Length; i++)
            {
                M4A1[i].enabled = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            isHavM4A1 = true;
            animation.Play("draw");
            for (int i = 0; i < Ak47.Length; i++)
            {
                Ak47[i].enabled = false;
                //메쉬렌더러 활성화
            }
            Spas12.enabled = false;
            for (int i = 0; i < M4A1.Length; i++)
            {
                M4A1[i].enabled = true;
            }
        }
    }
}
