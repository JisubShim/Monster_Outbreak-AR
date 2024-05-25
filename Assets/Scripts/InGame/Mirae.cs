using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mirae : MonoBehaviour
{
    [SerializeField]
    private GameObject damagePannel; // 데미지 패널

    [SerializeField]
    private AudioClip damageClip; // 데미지 입었을 때 사운드

    [SerializeField]
    private AudioClip dieClip; // 죽었을 때 사운드

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
        // 매 프레임마다 미래관의 위치를 초기 위치로 설정 -> 이동하지 않음
        transform.position = initialPos;
    }

    // 데미지 입음
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

            yield return new WaitForSeconds(1f); // 0.1초 동안 데미지 패널 띄우기
            damagePannel.SetActive(false);
        }
    }

    
}
