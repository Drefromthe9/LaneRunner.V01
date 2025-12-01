using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Call this on the Restart button
    public void RestartLevel()
    {
        // reload current gameplay scene - change name if you want to load a specific scene
        SceneManager.LoadScene("GameScene"); // set to your gameplay scene name
        Time.timeScale = 1f; // ensure timeScale is normal
    }

    // Call this on the Main Menu button
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // set to your main menu scene name
        Time.timeScale = 1f;
    }
}
