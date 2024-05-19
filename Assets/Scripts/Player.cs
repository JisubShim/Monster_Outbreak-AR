using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ü��
// �� �߻� ȣ��
// ���� ȣ��
// ���� ���� Ȯ��
public class Player : MonoBehaviour
{
    private bool isDie = false; // �÷��̾� ���� ����

    private AudioSource playerAudio;

    private Gun gun;

    [SerializeField]
    private GameObject shotButton; // ��� ��ư

    [SerializeField]
    private GameObject reloadButton; // ���� ��ư
    
    [SerializeField]
    private Text ammoText; // �Ѿ� �ؽ�Ʈ
    
    [SerializeField]
    private Text hpText; // ü�� �ؽ�Ʈ
    
    [SerializeField]
    private GameObject damagePannel; // ������ �г�
    
    [SerializeField]
    private AudioClip damageClip; // ������ �Ծ��� �� ����
    
    [SerializeField]
    private AudioClip dieClip; // �׾��� �� ����

    public float hp; // ü��

    public Image aimingPoint; // ������ �̹���

    private GameObject targetEnemy; // ���ص� ��

    private Vector3 hitPos; // ������ ���� Pos

    private Enemy enemy;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // �� �߻�
    public void Shooting()
    {
        if(!isDie)
        {
            gun.GunShot();
            Debug.Log("shoot!");

            Handheld.Vibrate(); // ��� ����

            if(targetEnemy!= null )
            {
                Enemy tenemy = targetEnemy.GetComponent<Enemy>();
                tenemy.Damage(hitPos, gun.gunDamage);
            }
        }
    }

    // ������
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
                targetEnemy = gunHit.collider.gameObject; // ray�� �ε��� object
                hitPos = gunHit.point; // ray�� ���� ��ġ
            }
        }
        else
        {
            aimingPoint.color = Color.white;
            targetEnemy = null;
            hitPos = Vector3.zero;
        }
    }

    // ������ ����
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
            
            yield return new WaitForSeconds(0.1f); // 0.1�� ���� ������ �г� ����
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