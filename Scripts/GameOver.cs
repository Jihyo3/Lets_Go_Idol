using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        player = GetComponent<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FallingObject"))
        {
            ScoreManager.instance.score = Score.instance.time;
            SceneManager.LoadScene(3);
        }
    }

    public void RetryBtnClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void StartSceneBtnClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
