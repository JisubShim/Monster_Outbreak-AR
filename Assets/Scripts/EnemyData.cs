using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ����
[CreateAssetMenu(menuName = "ScriptableObject/EnemyData", fileName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    public float enemyHp; // ü��
    public float enemyDamage; // ���ݷ�
    public float enemySpeed; // �̼�
    public float enemyAttackSpeed; // ����

    public AudioClip enemyDieClip; // �״� �Ҹ�
    public AudioClip enemyAttackClip; // ���� �Ҹ�
    public AudioClip enemyHitClip; // �ǰ� �Ҹ�
}