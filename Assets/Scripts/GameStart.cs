using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public bool isStart = false; // ���� ���۵Ǿ�����

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
                Application.Quit(); // ���ø����̼� ����
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
                gameText.text = "���� ���۱��� " + gameStartTime.ToString("F1") + '��';

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
                gameText.text = "���� ���۱��� " + gameStartTime.ToString("F1") + '��';

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
