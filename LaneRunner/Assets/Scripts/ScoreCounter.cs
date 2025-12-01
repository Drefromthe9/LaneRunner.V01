using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreText;
    private int score;

    // Update is called once per frame
    void Update()
    {
        score = (int)Time.time;
        scoreText.text = "Score: " + score.ToString();
        
    }
}
