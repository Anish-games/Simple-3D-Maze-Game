using TMPro;
using UnityEngine;

public class FinalScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  
    public CountdownTimer countdownTimer; 
    public int levelScore = 10;       // Points for each second remaining

    public void DisplayFinalScore()
    {
        // Calculate time spent
        float timeSpent = countdownTimer.GetTimeSpent();

        // Calculate the final score
        float finalScore = Mathf.Max(0, (300f - timeSpent)) * levelScore;

        // Display the final score
        scoreText.text = "Final Score: " + Mathf.FloorToInt(finalScore);
    }
}