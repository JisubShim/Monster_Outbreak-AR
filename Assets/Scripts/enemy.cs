using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾� ����
// ����
public class enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyData enemyData;

    [SerializeField]
    private ParticleSystem HitEffect; // �ǰ� ȿ��

    private float enemyHp; // ü��
    private float enemyDamage; // ���ݷ�
    private float enemySpeed; // �̼�
    private float enemyAttackSpeed; // ����
    private bool isDie = false; // �׾����� ���׾�����

    private GameObject playerObj;
    private Animator enemyAnim;
    private AudioSource enemyAudio;

    public event Action Death;

    private bool isStop = false;
    private float isStopTime = 2f;

    private float distance; // �÷��̾���� �Ÿ�
    private bool isAttack = false; // ���� ����

    void Start()
    {
        enemyAnim = this.GetComponent<Animator>();
        enemyAudio = this.GetComponent<AudioSource>();

        EnemySetting(enemyData);
    }

    private void EnemySetting(EnemyData enemyData)
    {
        enemyHp = enemyData.enemyHp;
        enemyDamage = enemyData.enemyDamage;
        enemySpeed = enemyData.enemySpeed;
        enemyAttackSpeed = enemyData.enemyAttackSpeed;
    }

    void Update()
    {
        
    }
}
