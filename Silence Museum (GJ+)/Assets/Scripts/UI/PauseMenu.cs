using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ContinueButton(); 
            }
            else
            {
                PausePanel(); 
            }
        }
    }

    public void PausePanel()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        isPaused = true; 
    }

    public void ContinueButton()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        isPaused = false; 
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
