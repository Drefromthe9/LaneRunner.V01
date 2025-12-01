using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText; // assign in Inspector

    [Header("Scoring")]
    [SerializeField] private float pointsPerSecond = 1f; // points gained each real second
    [SerializeField] private int pointsPerCoin = 10;     // points added per coin

    private float scoreFloat = 0f;   // internal floating score (keeps fractions from Time.deltaTime)
    private bool isGameOver = false;

    // Saved final score for Game Over screen (static so it's easy to read from other scenes)
    public static int finalScore = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // Optional: keep across scenes
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    private void Update()
    {
        if (isGameOver) return;

        // Add time-based points every frame
        scoreFloat += pointsPerSecond * Time.deltaTime;

        // Update UI with integer version
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + GetScoreInt();
        }
    }

    // Called by coin-collecting code
    public void AddCoinBonus(int coinCount = 1)
    {
        scoreFloat += coinCount * pointsPerCoin;
        UpdateScoreUI();
    }

    // Optional helper if you want to add arbitrary points
    public void AddPoints(int points)
    {
        scoreFloat += points;
        UpdateScoreUI();
    }

    public int GetScoreInt()
    {
        return Mathf.FloorToInt(scoreFloat);
    }

    // Call this when the game ends
    public void EndGameAndSaveScore()
    {
        if (isGameOver) return;
        isGameOver = true;
        finalScore = GetScoreInt();
        // You can also trigger your GameOver UI / scene load here if needed
    }
}
