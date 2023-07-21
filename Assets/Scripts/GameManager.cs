using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    public static bool IsGameOver = false;
    private int indexToShowModifier = 1;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI gameOverText;

    public void CheckWinState()
    {
        int aliveCount = 0;

        foreach (GameObject player in players)
        {
            if (player.activeSelf)
            {
                aliveCount++;
            }
        }
        if (aliveCount <= 1)
        {
            int remainingIndex = Array.IndexOf(players, players.FirstOrDefault(player => player.activeSelf));
            int remainingPlayer = remainingIndex + indexToShowModifier;
            gameOverText.text = ("Player " + remainingPlayer + " win with score: " + Player.score);
            IsGameOver = true;
            ShowGameOverUI();
        }
    }

    public void NewRound()
    {
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
        IsGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
