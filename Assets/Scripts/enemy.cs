using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 추적
// 공격
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyData enemyData;

    [SerializeField]
    private ParticleSystem HitEffect; // 피격 효과

    [SerializeField]
    private float enemyHp; // 체력
    private float enemyDamage; // 공격력
    private float enemySpeed; // 이속
    private float enemyAttackSpeed; // 공속
    private bool isDie = false; // 죽었는지 안죽었는지

    private GameObject playerObject;
    private Animator enemyAnimator;
    private AudioSource enemyAudio;

    public event Action Death;

    private bool isHit = false;
    private float stopTime = 1.8f;


    private float distance; // 플레이어와의 거리
    private bool isAttack = false; // 공격 구분
    private float attackSpeed = 2f; // 공속 (공격 간격)

    void Start()
    {
        enemyAnimator = this.GetComponent<Animator>();
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

    private void EnemyMove()
    {
        
        if (playerObject == null)
        {
            playerObject = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            if (!isHit) // 공격을 안맞았으면
            {
                enemyAnimator.SetBool("Move", true);
                distance = Vector3.Distance(this.transform.position, playerObject.transform.position);

                if(distance >= 4)
                {
                    this.transform.Translate(0,0,enemySpeed * Time.deltaTime);
                }
            }
            
            Vector3 targetPosition = playerObject.transform.position - new Vector3(0f, 3f, 0f);
            this.transform.LookAt(targetPosition);
        }
    }

    private void EnemyStop()
    {
        
        if (isHit) // 맞으면
        {
            stopTime -= Time.deltaTime;

            enemyAnimator.SetBool("Hit", true);

            if (stopTime <= 0)
            {
                stopTime = 0.5f;
                isHit = false;
                enemyAnimator.SetBool("Hit", false);
            }
        }
    }

    public void Damage(Vector3 hitPos, float damage)
    {
        if (!isDie)
        {
            enemyAnimator.SetBool("Move", false);
            isHit = true;
        }

        HitEffect.transform.position = hitPos;
        HitEffect.Play();

        enemyHp -= damage;

        if(enemyHp <= 0 && !isDie)
        {
            Death();
            isDie = true;
            enemyAnimator.SetTrigger("Death");

            Destroy(this.gameObject, 2f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null && !isAttack)
            {
                isAttack = true;
                enemyAnimator.SetTrigger("Attack");
                StartCoroutine(player.PlayerDamaged(enemyDamage));
            }
        }
    }
    void Update()
    {
        if (!isDie) // 안죽었을 때만
        {
            
                EnemyMove();
            
            
                EnemyStop();

            if (isAttack)
            {
                attackSpeed -= Time.deltaTime;
                if(attackSpeed <= 0)
                {
                    
                    isAttack = false;
                    attackSpeed = 2f;
                }
            }
        }
    }
}
