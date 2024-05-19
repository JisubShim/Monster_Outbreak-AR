using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public bool isStart = false; // 게임 시작되었는지

    private EnemySpawner spawner;

    public Text stageText;

    public Text gameText;

    public float gameStartTime = 1f;

    public GameObject startUI;

    public GameObject nextUI;

    public void GameStartButton()
    {
        if (!isStart)
            isStart = true;
    }

    public void GameExit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit(); // 어플리케이션 종료
        #endif
    }

    void Start()
    {
        spawner = FindObjectOfType<EnemySpawner>();
    }

    void Update()
    {
        if (isStart)
        {
            if (spawner.wave == 1)
            {
                gameStartTime -= Time.deltaTime;
                gameText.text = "게임 시작까지 " + gameStartTime.ToString("F1") + '초';

                if (gameStartTime <= 0)
                {
                    isStart = false;
                    spawner.isStart = true;
                    Debug.Log("Spawner is now starting");
                    startUI.SetActive(false);


                }
            }
            else if(spawner.wave == 2)
            {
                startUI.SetActive(true);
                gameStartTime -= Time.deltaTime;
                gameText.text = "게임 시작까지 " + gameStartTime.ToString("F1") + '초';

                if (gameStartTime <= 0)
                {
                    isStart = false;
                    spawner.isStart = true;
                    Debug.Log("Spawner is now starting");
                    startUI.SetActive(false);


                }
            }
        }
    }
}
