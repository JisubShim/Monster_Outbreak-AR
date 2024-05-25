using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� ������ ����

// ScriptableObject -> ������ �����͸� ������Ʈ �������� ����
[CreateAssetMenu(menuName = "ScriptableObject/GunData", fileName = "GunData")]
public class GunData : ScriptableObject
{
    public float gunDamage = 10f; // �� ������
    public int remainAmmo = 100; // ���� �Ѿ� ��
    public int maxAmmo = 30; // �ִ� �Ѿ� ��
    public float shotTime = 0.12f; // �߻� ������ �ð�
    public float reloadTime = 1.8f; // ���� �ð�

    public AudioClip shotClip; // �߻� �Ҹ�
    public AudioClip reloadClip; // ���� �Ҹ�

}