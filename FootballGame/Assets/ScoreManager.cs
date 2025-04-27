using UnityEngine;
using UnityEngine.UI; // Required for standard UI Text
using TMPro; // Required for TextMeshPro UGUI

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int targetScore = 400000;
    public TextMeshProUGUI scoreText;

    private int currentScore = 0;

    void Awake()
    {
        // Implement the Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    void Start()
    {
        currentScore = 0;
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        Debug.Log($"Score: {currentScore} / {targetScore}"); // For testing
        UpdateScoreUI();

        // Optional: Check win condition directly here if you don't use a GameManager
        // if (HasReachedTarget() && GameManager.Instance != null)
        // {
        //     GameManager.Instance.CheckWinCondition(); // Tell GameManager score target reached
        // }
    }

    public bool HasReachedTarget()
    {
        return currentScore >= targetScore;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            // Example format: "Score: 1500 / 400000"
            scoreText.text = $"Score: {currentScore} / {targetScore}";
            // Or just show current score: scoreText.text = $"Score: {currentScore}";
        }
        else
        {
            Debug.LogWarning("Score Text UI element not assigned in ScoreManager!");
        }
    }
}