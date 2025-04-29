using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading scenes

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton

    private bool gameHasEnded = false;
    private string exitSceneName = "Exit Scene"; // <<< Make sure this matches your scene name EXACTLY
    public const string FinalScoreKey = "FinalScore"; // Key for PlayerPrefs

    void Awake()
    {
        // Implement the Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameHasEnded = false;
        Time.timeScale = 1f; // Ensure game time is running normally
    }

    void Update()
    {
        // No longer checking for win condition here.
        // Game end is triggered ONLY by the timer via CheckLoseCondition.
        if (gameHasEnded) return; // Only necessary if other things could potentially call TriggerGameEnd

    }

    // Called by TimerManager when time runs out
    public void CheckLoseCondition()
    {
        if (gameHasEnded) return;

        // Time is up! Always trigger the end sequence regardless of score.
        Debug.Log("Time's Up! Transitioning to Exit Scene.");
        TriggerGameEnd();
    }

    // Called only when the timer expires
    void TriggerGameEnd()
    {
        if (gameHasEnded) return;

        gameHasEnded = true;
        Debug.Log("Timer expired. Preparing to load Exit Scene.");

        // Stop timers or other ongoing processes if needed
        if (TimerManager.Instance != null)
        {
            TimerManager.Instance.StopTimer();
        }

        // Get the final score
        int finalScore = 0;
        if (ScoreManager.Instance != null)
        {
            finalScore = ScoreManager.Instance.GetCurrentScore();
            Debug.Log($"Final score recorded: {finalScore}");
        }
        else
        {
            Debug.LogWarning("ScoreManager not found when trying to record final score.");
        }

        // Store the final score using PlayerPrefs
        PlayerPrefs.SetInt(FinalScoreKey, finalScore);
        PlayerPrefs.Save(); // Force save immediately (optional but good practice here)

        // Reset timescale JUST IN CASE
        Time.timeScale = 1f;

        // Load the Exit Scene
        SceneManager.LoadScene(exitSceneName);
    }
}