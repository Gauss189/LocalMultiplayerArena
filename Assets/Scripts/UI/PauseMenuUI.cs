using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    public static bool IsPaused = false; 
    [SerializeField] private GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(PlayerController.playerOnePauseButton) || Input.GetKeyDown(PlayerController.playerTwoPauseButton))
        {
            if (IsPaused)
            {
                Resume();
            }
            else Pause();
        }
    }

    public void Resume()
    {
        IsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        MainMenuUI.QuitGame();
    }
}  
