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

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // �� �߻�
    public void Shooting()
    {
        gun.GunShot();
        Debug.Log("shoot!");
    }

    // ������
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