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

    private GameObject targetEnemy; // 조준된 적

    private Vector3 hitPos; // 총으로 맞춘 Pos

    private Enemy enemy;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // 총 발사
    public void Shooting()
    {
        if(!isDie)
        {
            gun.GunShot();
            Debug.Log("shoot!");

            Handheld.Vibrate(); // 기기 진동

            if(targetEnemy!= null )
            {
                Enemy tenemy = targetEnemy.GetComponent<Enemy>();
                tenemy.Damage(hitPos, gun.gunDamage);
            }
        }
    }

    // 재장전
    public void Reloading()
    {
        gun.GunReload();
        Debug.Log("Reload!");
    }

    private void DetectTarget()
    {
        RaycastHit gunHit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out gunHit, Mathf.Infinity))
        {
            if (gunHit.collider.tag.Equals("Enemy"))
            {
                aimingPoint.color = Color.red;
                targetEnemy = gunHit.collider.gameObject; // ray에 부딪힌 object
                hitPos = gunHit.point; // ray에 맞은 위치
            }
        }
        else
        {
            aimingPoint.color = Color.white;
            targetEnemy = null;
            hitPos = Vector3.zero;
        }
    }

    // 데미지 입음
    public IEnumerator PlayerDamaged(float EenemyDamage)
    {
         
        if (!isDie)
        {
            hp -= EenemyDamage;

            if(hp <= 0)
            {
                isDie = true;
            }
            damagePannel.SetActive(true);
            
            yield return new WaitForSeconds(0.1f); // 0.1초 동안 데미지 패널 띄우기
            damagePannel.SetActive(false);
        }
    }

    private void DisplayUI()
    {
        hpText.text = "HP : " + hp.ToString();
        ammoText.text = gun.magAmmo.ToString() +'/' + gun.remainAmmo.ToString();
    }

    private void Update()
    {

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100, Color.green);
        
        if (gun == null)
        {
            gun = GameObject.FindObjectOfType<Gun>();
        }

        if (!isDie)
        {
            DetectTarget();
            DisplayUI();
        }
            
    }
}