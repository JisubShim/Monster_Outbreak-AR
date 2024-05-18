using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ������ ���� �ҷ���
// �� �߻�
// ����

public class Gun : MonoBehaviour
{
    public GunData gunData; // �� ������
    public int remainAmmo; // ���� ��ü �Ѿ� ��
    public int magAmmo; // źâ �� �Ѿ� ��
    public float gunDamage; // �� ������

    private float lastshotTime; // ���������� ���� �� �ð�
    private float reloadTime; // ���� �ð�
    private float shotTime; // �߻� �ð�
    private bool isReady = true; // �� �߻� ��������

    public AudioSource gunAudio; // �� �Ҹ�
    public ParticleSystem shotEffect; // �� �߻� ��ƼŬ
    
    void Start()
    {
        gunAudio = GetComponent<AudioSource>();
        GunSetting(gunData);
    }

    // �� ������ ����
    private void GunSetting(GunData gunData)
    {
        gunDamage = gunData.gunDamage;
        remainAmmo = gunData.remainAmmo;
        magAmmo = gunData.maxAmmo;
        reloadTime = gunData.reloadTime;
        shotTime = gunData.shotTime;
    }
    
    // �� ���
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

    // ����
    public void GunReload()
    {
        if(isReady)
        {
            // ���� �Ѿ��� �ְ�, źâ �� �Ѿ��� ���� ��������
            if(remainAmmo > 0 && magAmmo < gunData.maxAmmo)
            {
                StartCoroutine(GunReloadProcess());
            }
        }
    }

    // ���� �ڷ�ƾ
    private IEnumerator GunReloadProcess()
    {
        // ���� �� �ൿ ����
        isReady = false;

        //���� �Ҹ� ���
        gunAudio.PlayOneShot(gunData.reloadClip);

        // reload time��ŭ ��ٸ�
        yield return new WaitForSeconds(reloadTime);

        // ����
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
