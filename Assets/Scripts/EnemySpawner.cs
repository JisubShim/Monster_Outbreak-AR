using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public bool isStart = false; // 게임 시작되었는지

    public int wave = 1; // 몇 웨이브인지

    public List<GameObject> enemyList = new List<GameObject>();

    [SerializeField]
    private GameObject[] stageEnemys;

    private int enemyCount = 15;

    private bool isSpawn = false;

    private GameStart gameStart;

    void Start()
    {
        gameStart = FindObjectOfType<GameStart>();
    }

    void Update()
    {
        if (isStart)
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
                }
            }
            
        }
    }

    public void GameStartButton()
    {
        if (!isStart)
            isStart = true;
    }

    private void SpawnEnemy()
    {
        isSpawn = true;

        for(int i = 0; i < enemyCount * wave; i++)
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
                maxX = -60;
                minZ = -20;
                minZ = -60;
            }
            else if(randomRange == 1)
            {
                minX = 20;
                maxX = 60;
                minZ = 20;
                minZ = 60;
            }
            else if(randomRange == 2)
            {
                minX = 20;
                maxX = 60;
                minZ = -20;
                minZ = -60;
            }
            else if(randomRange == 3)
            {
                minX = -20;
                maxX = -60;
                minZ = 20;
                minZ = 60;
            }

            spawnX = Random.Range(minX, maxX);
            spawnZ = Random.Range(minZ, maxZ);

            Enemy spawnEnemy
            = Instantiate(stageEnemys[wave - 1].GetComponent<Enemy>(),
            new Vector3(spawnX, -1f, spawnZ), Quaternion.identity);

            // 생성한 적을 리스트에 추가
            enemyList.Add(spawnEnemy.gameObject);

            // 대리자 호출
            spawnEnemy.Death += () => enemyList.Remove(spawnEnemy.gameObject);
        }
    }

    public void NextButton()
    {
        
        isStart = false;
        isSpawn = false;
        gameStart.gameStartTime = 3f;
        wave++;
        gameStart.nextUI.SetActive(false);
        gameStart.startUI.SetActive(true);

    }
}
