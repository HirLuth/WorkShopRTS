using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;
    public bool isPaused;

    private void Start()
    {
        panel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene("MENU");
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
