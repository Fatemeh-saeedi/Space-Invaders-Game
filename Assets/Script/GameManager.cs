using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject winnerUI;
    public GameObject loserUI;

    private int totalEnemies;
    private int enemiesKilled;
    private int playerLives = 3;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Time.timeScale = 1f;
        totalEnemies = Object.FindObjectsByType<Invader>(FindObjectsSortMode.None).Length;
    }

    public void EnemyKilled()
    {
        enemiesKilled++;

        if (enemiesKilled >= totalEnemies)
        {
            WinGame();
        }
    }

    public void PlayerHit()
    {
        playerLives--;

        if (playerLives <= 0)
        {
            LoseGame();
        }
    }

    private void WinGame()
    {
        Time.timeScale = 0f;
        if (winnerUI != null) winnerUI.SetActive(true);
    }

    private void LoseGame()
    {
        Time.timeScale = 0f;
        if (loserUI != null) loserUI.SetActive(true);
    }
}