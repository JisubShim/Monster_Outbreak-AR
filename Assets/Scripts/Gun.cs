using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 총 데이터 정보 불러옴
// 총 발사
// 장전

public class Gun : MonoBehaviour
{
    public GunData gunData; // 총 데이터
    public int remainAmmo; // 남은 전체 총알 수
    public int magAmmo; // 탄창 안 총알 수
    public float gunDamage; // 총 데미지

    private float lastshotTime; // 마지막으로 총을 쏜 시간
    private float reloadTime; // 장전 시간
    private float shotTime; // 발사 시간
    private bool isReady = true; // 총 발사 가능한지

    public AudioSource gunAudio; // 총 소리
    public ParticleSystem shotEffect; // 총 발사 파티클
    
    void Start()
    {
        gunAudio = GetComponent<AudioSource>();
        GunSetting(gunData);
    }

    // 총 데이터 세팅
    private void GunSetting(GunData gunData)
    {
        gunDamage = gunData.gunDamage;
        remainAmmo = gunData.remainAmmo;
        magAmmo = gunData.maxAmmo;
        reloadTime = gunData.reloadTime;
        shotTime = gunData.shotTime;
    }
    
    // 총 쏘기
    public void GunShot()
    {
        if (isReady)
        {
            if(magAmmo > 0 && Time.time > lastshotTime + shotTime)
            {
                shotEffect.Play();
                //shellEffect.Play();
                magAmmo--;
                lastshotTime = Time.time;
                gunAudio.PlayOneShot(gunData.shotClip);
            }
        }
    }

    // 장전
    public void GunReload()
    {
        if(isReady)
        {
            // 남은 총알이 있고, 탄창 안 총알이 가득 차지않음
            if(remainAmmo > 0 && magAmmo < gunData.maxAmmo)
            {
                StartCoroutine(GunReloadProcess());
            }
        }
    }

    // 장전 코루틴
    private IEnumerator GunReloadProcess()
    {
        // 장전 중 행동 제한
        isReady = false;

        //장전 소리 재생
        gunAudio.PlayOneShot(gunData.reloadClip);

        // reload time만큼 기다림
        yield return new WaitForSeconds(reloadTime);

        // 장전
        int ammoFill = gunData.maxAmmo - magAmmo;

        if(ammoFill > remainAmmo)
        {
            ammoFill = remainAmmo;
        }
        magAmmo += ammoFill;
        remainAmmo -= ammoFill;

        isReady = true;
    }
}
