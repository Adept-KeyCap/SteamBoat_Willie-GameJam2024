using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private Chronometer Chrono;

    private void Start()
    {
        Chrono = FindFirstObjectByType<Chronometer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Chrono.ResumeGame();
    }
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
  
}
