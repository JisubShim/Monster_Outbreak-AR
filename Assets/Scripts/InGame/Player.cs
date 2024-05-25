using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 체력
// 총 발사 호출
// 장전 호출
// 몬스터 조준 확인
public class Player : MonoBehaviour
{
    

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
    
    

    public Image aimingPoint; // 조준점 이미지

    private GameObject targetEnemy; // 조준된 적

    private Vector3 hitPos; // 총으로 맞춘 Pos

    private Enemy enemy;

    [SerializeField]
    private GameObject AmmoLackPannel;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100, Color.green);

        if (gun == null)
        {
            gun = GameObject.FindObjectOfType<Gun>();
        }

        if (!GameManager.instance.isDestroy)
        {
            DetectTarget();
            DisplayUI();
        }
        else
        {

        }
    }

    // 총 발사
    public void Shooting()
    {
        if(!GameManager.instance.isDestroy)
        {
            gun.GunShot();
            Debug.Log("shoot!");

            Handheld.Vibrate(); // 기기 진동

            if(targetEnemy!= null && GameManager.instance.magAmmo > 0)
            {
                Enemy tenemy = targetEnemy.GetComponent<Enemy>();
                tenemy.Damage(hitPos, gun.gunDamage);
            }
            else if(GameManager.instance.magAmmo <= 0)
            {
                StartCoroutine(AmmoLack());
            }
        }
    }

    public IEnumerator AmmoLack()
    {

        if (!GameManager.instance.isDestroy)
        {
            AmmoLackPannel.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            AmmoLackPannel.SetActive(false);
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

    

    private void DisplayUI()
    {
        hpText.text = "HP : " + GameManager.instance.hp.ToString();
        ammoText.text = GameManager.instance.magAmmo.ToString() +'/' + GameManager.instance.remainAmmo.ToString();
    }

    
}