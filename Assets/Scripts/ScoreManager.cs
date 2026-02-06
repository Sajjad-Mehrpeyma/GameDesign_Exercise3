using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private const string BestKey = "BestScore";

    [Header("UI References")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestText;

    [Header("Legacy Text (اگر TextMeshPro ندارید)")]
    public Text scoreTextLegacy;
    public Text bestTextLegacy;

    [Header("Score Settings")]
    public float scoreMultiplier = 1f;

    public float CurrentScore { get; private set; }
    public float BestScore { get; private set; }

    private void Start()
    {
        LoadBestScore();
        UpdateUI();
    }

    public void AddScore(float deltaTime)
    {
        CurrentScore += deltaTime * scoreMultiplier;
        UpdateUI();
    }

    public void ResetScore()
    {
        CurrentScore = 0f;
        UpdateUI();
    }

    public void SaveBestScore()
    {
        if (CurrentScore > BestScore)
        {
            BestScore = CurrentScore;
            PlayerPrefs.SetFloat(BestKey, BestScore);
            PlayerPrefs.Save();
        }
        UpdateUI();
    }

    private void LoadBestScore()
    {
        BestScore = PlayerPrefs.GetFloat(BestKey, 0f);
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {CurrentScore:0}";
        }
        else if (scoreTextLegacy != null)
        {
            scoreTextLegacy.text = $"Score: {CurrentScore:0}";
        }

        if (bestText != null)
        {
            bestText.text = $"Best: {BestScore:0}";
        }
        else if (bestTextLegacy != null)
        {
            bestTextLegacy.text = $"Best: {BestScore:0}";
        }
    }
}

