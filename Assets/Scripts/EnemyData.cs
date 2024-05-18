using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 적 정보
[CreateAssetMenu(menuName = "ScriptableObject/EnemyData", fileName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    public float enemyHp; // 체력
    public float enemyDamage; // 공격력
    public float enemySpeed; // 이속
    public float enemyAttackSpeed; // 공속

    public AudioClip enemyDieClip; // 죽는 소리
    public AudioClip enemyAttackClip; // 공격 소리
    public AudioClip enemyHitClip; // 피격 소리
}