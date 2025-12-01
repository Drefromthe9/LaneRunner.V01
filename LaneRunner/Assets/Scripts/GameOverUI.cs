using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText; // assign in Inspector

    private void OnEnable()
    {
        // When this UI shows up, pull the saved final score from ScoreManager
        int score = ScoreManager.finalScore;
        if (finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + score;
        }
    }
}
