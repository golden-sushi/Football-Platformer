using UnityEngine;
using TMPro;          // Use this for TextMeshPro

public class LeaderBoardSCore : MonoBehaviour

  {
    public TextMeshProUGUI finalScoreTextElement; // For TextMeshPro Text

    private const string ScorePlayerPrefsKey = "FinalScore";

    void Start()
    {
        if (finalScoreTextElement == null)
        {
            Debug.LogError("[EndScreenUI] ERROR: The 'Final Score Text Element' has not been assigned in the Inspector! Cannot display score.");
            return;
        }

        int finalScore = PlayerPrefs.GetInt(ScorePlayerPrefsKey, 0);
        Debug.Log($"[EndScreenUI] Retrieved score from PlayerPrefs using key '{ScorePlayerPrefsKey}': {finalScore}");

        finalScoreTextElement.text = $"{finalScore}"; 

        // Optional: Clear the saved score from PlayerPrefs
        PlayerPrefs.DeleteKey(ScorePlayerPrefsKey);
}
  }