using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//총 데이터 정보

// ScriptableObject -> 간단한 데이터를 오브젝트 형식으로 담음
[CreateAssetMenu(menuName = "ScriptableObject/GunData", fileName = "GunData")]
public class GunData : ScriptableObject
{
    public float gunDamage = 10f; // 총 데미지
    public int remainAmmo = 100; // 남은 총알 수
    public int maxAmmo = 30; // 최대 총알 수
    public float shotTime = 0.12f; // 발사 딜레이 시간
    public float reloadTime = 1.8f; // 장전 시간

    public AudioClip shotClip; // 발사 소리
    public AudioClip reloadClip; // 장전 소리

}