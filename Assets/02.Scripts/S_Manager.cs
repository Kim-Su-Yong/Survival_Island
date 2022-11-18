using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//씬관련 기능을 가져 오기 위해 선언

public class S_Manager : MonoBehaviour
{
    private void Start()
    {   //마우스 커서 보이게 하기
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        /*
         마우스 커서 숨기기
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        */
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayScene");
        //다음 씬으로 이동
    }

    public void QuitGame()
    {
        Application.Quit();
        //프로그램 종료
    }
}
