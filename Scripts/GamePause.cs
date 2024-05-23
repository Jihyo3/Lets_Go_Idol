using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    private Button pauseBtn;
    [SerializeField]
    private GameObject pauseMenu;

    private void Awake()
    {
        pauseBtn = GetComponent<Button>();
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
