using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public bool isDestroy = false; // �̷��� �ı� ����

    public bool isVictory = false;

    public float hp = 100; // ü��

    public int remainAmmo; // ���� ��ü �Ѿ� ��
    public int magAmmo; // źâ �� �Ѿ� ��

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