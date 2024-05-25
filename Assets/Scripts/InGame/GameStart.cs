using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public bool isStart = false; // 게임 시작되었는지

    private EnemySpawner spawner;

    public Text gameText;

    public Text gameText2;

    public Text gameText3;

    public float gameStartTime = 1f;

    public GameObject startUI;

    public GameObject nextUI;

    public GameObject middleUI;

    public GameObject endUI;

    public void GameStartButton()
    {
        if (!isStart)
            isStart = true;
    }

    public void HpRecovery()
    {
        if (!isStart)
            isStart = true;
        GameManager.instance.hp = 100;
    }

    public void AmmoRecovery()
    {
        if (!isStart)
            isStart = true;
        GameManager.instance.magAmmo = 30;
        GameManager.instance.remainAmmo = 100;
    }

    public void GameExit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit(); // 어플리케이션 종료
        #endif
    }
    public void BackToLobbyButton()
    {
        SceneManager.LoadScene("GameStart");
    }

    void Start()
    {
        spawner = FindObjectOfType<EnemySpawner>();
        GameManager.instance.isDestroy = false;
    }

    void Update()
    {
        if (isStart)
        {
            if (spawner.wave == 1 && !spawner.spawnerStart)
            {
                gameStartTime -= Time.deltaTime;
                gameText.text = "게임 시작까지 " + gameStartTime.ToString("F1") + '초';

                if (gameStartTime <= 0)
                {
                    spawner.spawnerStart = true;
                    Debug.Log("Spawner is now starting");
                    
                    startUI.SetActive(false);
                }
            }
            else if(spawner.wave == 2 && !spawner.spawnerStart)
            {
                gameStartTime -= Time.deltaTime;
                gameText2.text = "게임 시작까지 " + gameStartTime.ToString("F1") + '초';

                if (gameStartTime <= 0)
                {
                    spawner.spawnerStart = true;
                    Debug.Log("Spawner is now starting");
                    middleUI.SetActive(false);
                }
            }
            else if (spawner.wave == 3 && !spawner.spawnerStart)
            {
                gameStartTime -= Time.deltaTime;
                gameText3.text = "게임 시작까지 " + gameStartTime.ToString("F1") + '초';

                if (gameStartTime <= 0)
                {
                    spawner.spawnerStart = true;
                    Debug.Log("Spawner is now starting");
                    endUI.SetActive(false);
                }
            }
        }
    }
}
