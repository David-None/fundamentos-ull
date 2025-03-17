using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int totalScore;
    private TextMeshProUGUI scoreText;
    
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void RewriteScore(int score)
    {
        //Rewrite the current score in the UI
        totalScore += score;
        scoreText.text = "SCORE: " + totalScore.ToString();
    }
}
