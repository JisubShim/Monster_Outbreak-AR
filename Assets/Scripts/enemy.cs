using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾� ����
// ����
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyData enemyData;

    [SerializeField]
    private ParticleSystem HitEffect; // �ǰ� ȿ��

    [SerializeField]
    private float enemyHp; // ü��
    private float enemyDamage; // ���ݷ�
    private float enemySpeed; // �̼�
    private float enemyAttackSpeed; // ����
    private bool isDie = false; // �׾����� ���׾�����

    private GameObject playerObject;
    private Animator enemyAnimator;
    private AudioSource enemyAudio;

    public event Action Death;

    private bool isHit = false;
    private float stopTime = 1.8f;


    private float distance; // �÷��̾���� �Ÿ�
    private bool isAttack = false; // ���� ����
    private float attackSpeed = 2f; // ���� (���� ����)

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
            if (!isHit) // ������ �ȸ¾�����
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
        
        if (isHit) // ������
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
        if (!isDie) // ���׾��� ����
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
