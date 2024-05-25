using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public bool isDestroy = false; // 미래관 파괴 유무

    public bool isVictory = false;

    public float hp = 100; // 체력

    public int remainAmmo; // 남은 전체 총알 수
    public int magAmmo; // 탄창 안 총알 수

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
    }
}