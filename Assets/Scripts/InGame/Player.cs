using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// ü��
// �� �߻� ȣ��
// ���� ȣ��
// ���� ���� Ȯ��
public class Player : MonoBehaviour
{
    

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
    
    

    public Image aimingPoint; // ������ �̹���

    private GameObject targetEnemy; // ���ص� ��

    private Vector3 hitPos; // ������ ���� Pos

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

    // �� �߻�
    public void Shooting()
    {
        if(!GameManager.instance.isDestroy)
        {
            gun.GunShot();
            Debug.Log("shoot!");

            Handheld.Vibrate(); // ��� ����

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

    

    private void DisplayUI()
    {
        hpText.text = "HP : " + GameManager.instance.hp.ToString();
        ammoText.text = GameManager.instance.magAmmo.ToString() +'/' + GameManager.instance.remainAmmo.ToString();
    }

    
}