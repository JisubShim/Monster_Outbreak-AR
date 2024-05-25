using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ������ ���� �ҷ���
// �� �߻�
// ����

public class Gun : MonoBehaviour
{
    public GunData gunData; // �� ������
    
    public float gunDamage; // �� ������

    private float lastshotTime; // ���������� ���� �� �ð�
    private float reloadTime; // ���� �ð�
    private float shotTime; // �߻� �ð�
    private bool isReady = true; // �� �߻� ��������

    public AudioSource gunAudio; // �� �Ҹ�
    public ParticleSystem shotEffect; // �� �߻� ��ƼŬ
    
    void Start()
    {
        isReady = true;
        gunAudio = GetComponent<AudioSource>();
        GunSetting(gunData);
    }

    // �� ������ ����
    private void GunSetting(GunData gunData)
    {
        gunDamage = gunData.gunDamage;
        GameManager.instance.remainAmmo = gunData.remainAmmo;
        GameManager.instance.magAmmo = gunData.maxAmmo;
        reloadTime = gunData.reloadTime;
        shotTime = gunData.shotTime;
    }
    
    // �� ���
    public void GunShot()
    {
        if (isReady)
        {
            if (GameManager.instance.magAmmo > 0 && Time.time > lastshotTime + shotTime)
            {
                shotEffect.Play();
                GameManager.instance.magAmmo--;
                lastshotTime = Time.time;
                gunAudio.PlayOneShot(gunData.shotClip);
            }
        }
    }

    // ����
    public void GunReload()
    {
        if(isReady)
        {
            // ���� �Ѿ��� �ְ�, źâ �� �Ѿ��� ���� ��������
            if(GameManager.instance.remainAmmo > 0 && GameManager.instance.magAmmo < gunData.maxAmmo)
            {
                StartCoroutine(GunReloading());
            }
        }
    }

    // ���� �ڷ�ƾ
    private IEnumerator GunReloading()
    {
        // ���� �� �ൿ ����
        isReady = false;

        //���� �Ҹ� ���
        gunAudio.PlayOneShot(gunData.reloadClip);

        // reload time��ŭ ��ٸ�
        yield return new WaitForSeconds(reloadTime);

        // ����
        int ammoFill = gunData.maxAmmo - GameManager.instance.magAmmo;

        if(ammoFill > GameManager.instance.remainAmmo)
        {
            ammoFill = GameManager.instance.remainAmmo;
        }
        GameManager.instance.magAmmo += ammoFill;
        GameManager.instance.remainAmmo -= ammoFill;

        isReady = true;
    }
}
