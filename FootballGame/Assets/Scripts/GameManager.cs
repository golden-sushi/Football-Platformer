using UnityEngine;
using UnityEngine.SceneManagement; // Needed for restarting the scene

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton

    public GameObject winPanel; // Assign a UI Panel to show on win
    public GameObject losePanel; // Assign a UI Panel to show on lose

    private bool gameHasEnded = false;

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
        // Ensure panels are hidden at start
        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);
        Time.timeScale = 1f; // Ensure game time is running normally
    }

    void Update()
    {
        // Continuously check conditions if the game hasn't ended yet
        if (!gameHasEnded)
        {
            CheckWinCondition();
            // Lose condition is checked when TimerManager runs out of time
        }
    }

    public void CheckWinCondition()
    {
        if (gameHasEnded) return; // Don't check if already ended

        if (ScoreManager.Instance != null && ScoreManager.Instance.HasReachedTarget())
        {
            WinGame();
        }
    }

    public void CheckLoseCondition()
    {
         if (gameHasEnded) return; // Don't check if already ended

         // Primary lose condition: time runs out
         if (TimerManager.Instance != null && TimerManager.Instance.IsTimeUp())
         {
            // Only trigger lose if the win condition wasn't met simultaneously
            if (ScoreManager.Instance == null || !ScoreManager.Instance.HasReachedTarget())
            {
                 LoseGame();
            }
         }
         // You could add other lose conditions here (e.g., player health <= 0)
    }


    void WinGame()
    {
        if (gameHasEnded) return; // Prevent multiple triggers

        Debug.Log("YOU WIN!");
        gameHasEnded = true;
        Time.timeScale = 0f; // Pause the game

        if (TimerManager.Instance != null) TimerManager.Instance.StopTimer(); // Stop the timer visually

        if (winPanel != null)
        {
            winPanel.SetActive(true); // Show the win screen UI
        }
        // Add any other win effects (sound, animation, etc.)
    }

    void LoseGame()
    {
        if (gameHasEnded) return; // Prevent multiple triggers

        Debug.Log("YOU LOSE!");
        gameHasEnded = true;
        Time.timeScale = 0f; // Pause the game

         if (TimerManager.Instance != null) TimerManager.Instance.StopTimer(); // Ensure timer stops

        if (losePanel != null)
        {
            losePanel.SetActive(true); // Show the lose screen UI
        }
        // Add any other lose effects
    }

    // --- UI Button Functions ---

    public void RestartGame()
    {
        Time.timeScale = 1f; // IMPORTANT: Reset time scale before loading scene
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit(); // Note: This only works in a built game, not the Editor
    }
}