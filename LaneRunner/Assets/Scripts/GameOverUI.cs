using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private void OnEnable()
    {
        Debug.Log("GameOverUI: finalScore = " + ScoreManager.finalScore);

        if (finalScoreText == null)
        {
            Debug.LogError("GameOverUI: FINAL SCORE TEXT IS NOT ASSIGNED IN INSPECTOR!");
            return;
        }

        finalScoreText.text = "Final Score: " + ScoreManager.finalScore;
    }
}
