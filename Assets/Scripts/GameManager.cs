using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public PlayerController player;
    public ObstacleSpawner spawner;
    public ScoreManager scoreManager;
    public UIManager uiManager;

    [Header("Game State")]
    public bool isGameOver;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isGameOver = false;
        Time.timeScale = 1f;
        scoreManager.ResetScore();
        uiManager.HideGameOver();
    }

    public void OnPlayerDied()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f;
        scoreManager.SaveBestScore();
        uiManager.ShowGameOver();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (!isGameOver)
        {
            scoreManager.AddScore(Time.deltaTime);
        }
    }
}

