using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 추적
// 공격
public class enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyData enemyData;

    [SerializeField]
    private ParticleSystem HitEffect; // 피격 효과

    private float enemyHp; // 체력
    private float enemyDamage; // 공격력
    private float enemySpeed; // 이속
    private float enemyAttackSpeed; // 공속
    private bool isDie = false; // 죽었는지 안죽었는지

    private GameObject playerObj;
    private Animator enemyAnim;
    private AudioSource enemyAudio;

    public event Action Death;

    private bool isStop = false;
    private float isStopTime = 2f;

    private float distance; // 플레이어와의 거리
    private bool isAttack = false; // 공격 구분

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
