using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 체력
// 총 발사 호출
// 장전 호출
// 몬스터 조준 확인
public class Player : MonoBehaviour
{
    private bool isDie = false; // 플레이어 죽음 유무

    private AudioSource playerAudio;

    private Gun gun;

    [SerializeField]
    private GameObject shotButton; // 사격 버튼

    [SerializeField]
    private GameObject reloadButton; // 장전 버튼
    
    [SerializeField]
    private Text ammoText; // 총알 텍스트
    
    [SerializeField]
    private Text hpText; // 체력 텍스트
    
    [SerializeField]
    private GameObject damagePannel; // 데미지 패널
    
    [SerializeField]
    private AudioClip damageClip; // 데미지 입었을 때 사운드
    
    [SerializeField]
    private AudioClip dieClip; // 죽었을 때 사운드

    public float hp; // 체력

    public Image aimingPoint; // 조준점 이미지

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // 총 발사
    public void Shooting()
    {
        gun.GunShot();
        Debug.Log("shoot!");
    }

    // 재장전
    public void Reloading()
    {
        gun.GunReload();
        Debug.Log("Reload!");
    }

    private void RayTarget()
    {
        RaycastHit gunHit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out gunHit, Mathf.Infinity))
        {
            if (gunHit.collider.tag.Equals("Enemy"))
            {
                aimingPoint.color = Color.red;
            }
        }
        else
        {
            aimingPoint.color = Color.white;
        }
    }

    private void Update()
    {

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100, Color.green);
        
        if (gun == null)
        {
            gun = GameObject.FindObjectOfType<Gun>();
        }

        if (!isDie)
            RayTarget();
    }
}