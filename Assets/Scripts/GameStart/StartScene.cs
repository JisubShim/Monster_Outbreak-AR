using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    // 게임 시작
    public void StartButton()
    {
        SceneManager.LoadScene("InGame");
    }

    // 게임 종료
    public void GameExit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                        Application.Quit(); // 어플리케이션 종료
        #endif
    }
}
