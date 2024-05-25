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

    private GameObject miraeObject;
    private Animator enemyAnimator;
    private AudioSource enemyAudio;

    public event Action Death;

    private bool isHit = false;
    private float stopTime = 1.8f;


    private float distance; // �÷��̾���� �Ÿ�
    private bool isAttack = false; // ���� ����
    private float attackSpeed = 2f; // ���� (���� ����)

    private EnemySpawner enemySpawner;

    private bool animOne = false;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        enemySpawner = FindObjectOfType<EnemySpawner>();

        if(enemySpawner.wave == 2)
            enemyAudio.volume = 0.5f;
        
        EnemySetting(enemyData);
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
                if (attackSpeed <= 0)
                {
                    isAttack = false;
                    attackSpeed = 2f;
                }
            }
        }
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
        
        if (miraeObject == null)
        {
            miraeObject = GameObject.FindGameObjectWithTag("Mirae");
        }
        else
        {
            if (!isHit) // ������ �ȸ¾�����
            {
                enemyAnimator.SetBool("Move", true);
                distance = Vector3.Distance(transform.position, miraeObject.transform.position);

                if(distance >= 4)
                {
                    transform.Translate(0,0,enemySpeed * Time.deltaTime);
                }
            }
            
            Vector3 targetPosition = miraeObject.transform.position - new Vector3(0f, 3f, 0f);
            transform.LookAt(targetPosition);
        }
    }

    private void EnemyStop()
    {
        
        if (isHit) // ������
        {
            stopTime -= Time.deltaTime;
            if (animOne)
            {
                enemyAudio.PlayOneShot(enemyData.enemyHitClip);
                enemyAnimator.SetBool("Hit", true);
                animOne = true;
            }

            if (stopTime <= 0)
            {
                stopTime = 0.5f;
                animOne = false;
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
            enemyAudio.PlayOneShot(enemyData.enemyDieClip);
            enemyAnimator.SetTrigger("Death");

            Destroy(gameObject, 1f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Mirae")
        {
            Mirae mirae = other.GetComponent<Mirae>();

            if(mirae != null && !isAttack)
            {
                isAttack = true;
                enemyAudio.PlayOneShot(enemyData.enemyAttackClip);
                enemyAnimator.SetTrigger("Attack");
                StartCoroutine(mirae.PlayerDamaged(enemyDamage));
            }
        }
    }
    
}
