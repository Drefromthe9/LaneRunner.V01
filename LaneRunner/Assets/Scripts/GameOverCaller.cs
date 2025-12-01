using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCaller : MonoBehaviour
{
    public void TriggerGameOver()
    {
        // Save score
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.EndGameAndSaveScore();
            Debug.Log("Saved finalScore = " + ScoreManager.finalScore);
        }
        else
        {
            Debug.LogWarning("ScoreManager.Instance null when triggering game over. Using static finalScore = " + ScoreManager.finalScore);
        }

        // THEN load GameOver scene (replace with your actual scene name)
        SceneManager.LoadScene("GameOverScene");
    }
}
