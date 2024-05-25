using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    GameObject win;

    [SerializeField]
    GameObject lose;

    public void BackToLobbyButton()
    {
        SceneManager.LoadScene("GameStart");
    }

    private void Start()
    {
        if (GameManager.instance.isVictory)
        {
            lose.SetActive(false);
            win.SetActive(true);
            GameManager.instance.isVictory = false;
        }
        else
        {
            lose.SetActive(true);
            win.SetActive(false);
        }
        
    }
}
