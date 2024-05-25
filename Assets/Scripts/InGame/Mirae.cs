using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mirae : MonoBehaviour
{
    [SerializeField]
    private GameObject damagePannel; // ������ �г�

    [SerializeField]
    private AudioClip damageClip; // ������ �Ծ��� �� ����

    [SerializeField]
    private AudioClip dieClip; // �׾��� �� ����

    private Vector3 initialPos;

    void Start()
    {
        initialPos = transform.position;

        GameManager.instance.hp = 100;
        GameManager.instance.magAmmo = 30;
        GameManager.instance.remainAmmo = 100;
    }

    void Update()
    {
        // �� �����Ӹ��� �̷����� ��ġ�� �ʱ� ��ġ�� ���� -> �̵����� ����
        transform.position = initialPos;
    }

    // ������ ����
    public IEnumerator PlayerDamaged(float EenemyDamage)
    {

        if (!GameManager.instance.isDestroy)
        {
            GameManager.instance.hp -= EenemyDamage;

            if (GameManager.instance.hp <= 0)
            {
                GameManager.instance.isDestroy = true;
                SceneManager.LoadScene("GameOver");
            }
            damagePannel.SetActive(true);

            yield return new WaitForSeconds(1f); // 0.1�� ���� ������ �г� ����
            damagePannel.SetActive(false);
        }
    }

    
}
