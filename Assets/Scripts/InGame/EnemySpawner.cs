using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public bool spawnerStart = false; // ���� ���۵Ǿ�����

    public int wave = 1; // �� ���̺�����

    public List<GameObject> enemyList = new List<GameObject>();

    [SerializeField]
    private GameObject[] stageEnemys;

    private int enemyNum = 10; // �������� �� ���� �� : 10/20/30

    private bool isSpawn = false;

    private GameStart gameStart;

    public Text nextText;

    void Start()
    {
        gameStart = FindObjectOfType<GameStart>();
        wave = 1;
        spawnerStart = false;
        isSpawn = false;
    }

    void Update()
    {
        if (spawnerStart)
        {
            //isStart = false;
            if (!isSpawn)
            {
                SpawnEnemy();
            }
            else
            {
                if(enemyList.Count <= 0)
                {
                    gameStart.nextUI.SetActive(true);
                    if(wave == 1)
                    {
                        nextText.text = "1�� ���̺긦 ���Ƴ´�!";
                    }
                    else if(wave == 2)
                    {
                        nextText.text = "2�� ���̺긦 ���Ƴ´�!";
                    }
                    else if(wave == 3)
                    {
                        nextText.text = "3�� ���̺긦 ���Ƴ´�!";
                    }
                }
            }
            
        }
    }

    public void GameStartButton()
    {
        if (!spawnerStart)
            spawnerStart = true;
    }

    private void SpawnEnemy()
    {
        isSpawn = true;

        for(int i = 0; i < enemyNum + (wave-1)*10; i++)
        {
            float spawnX;
            float spawnZ;

            int randomRange = Random.Range(0, 4);

            int maxX = 0;
            int minX = 0;
            int maxZ = 0;
            int minZ = 0;

            if (randomRange == 0)
            {
                minX = -20;
                maxX = -50;
                minZ = -20;
                minZ = -50;
            }
            else if(randomRange == 1)
            {
                minX = 20;
                maxX = 50;
                minZ = 20;
                minZ = 50;
            }
            else if(randomRange == 2)
            {
                minX = 20;
                maxX = 50;
                minZ = -20;
                minZ = -50;
            }
            else if(randomRange == 3)
            {
                minX = -20;
                maxX = -50;
                minZ = 20;
                minZ = 50;
            }

            spawnX = Random.Range(minX, maxX);
            spawnZ = Random.Range(minZ, maxZ);

            Enemy spawnEnemy
            = Instantiate(stageEnemys[wave - 1].GetComponent<Enemy>(),
            new Vector3(spawnX, -1f, spawnZ), Quaternion.identity);

            // ������ ���� ����Ʈ�� �߰�
            enemyList.Add(spawnEnemy.gameObject);

            // ���� ������ ����Ʈ���� ����
            spawnEnemy.Death += () => enemyList.Remove(spawnEnemy.gameObject);
        }
    }

    public void NextButton()
    {
        gameStart.isStart = false;
        spawnerStart = false;
        isSpawn = false;
        gameStart.gameStartTime = 3f;
        wave++;
        gameStart.nextUI.SetActive(false);
        if(wave == 2)
        {
            gameStart.middleUI.SetActive(true);
        }
        if(wave == 3)
        {
            gameStart.endUI.SetActive(true);
        }
        if(wave == 4)
        {
            GameManager.instance.isVictory = true;
            SceneManager.LoadScene("GameOver");
        }
    }
}
