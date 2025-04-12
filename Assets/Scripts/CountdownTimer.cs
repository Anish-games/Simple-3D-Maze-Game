using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeRemaining = 300f; // Initial countdown time
    private bool timerRunning = true;
    public GameManager gameManager;

    void Update()
    {
        if (timerRunning)
        {
            // When paused, Time.deltaTime becomes zero so the timer stops automatically.
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;
                DisplayTime(timeRemaining);
                gameManager.PlayerLoses();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay = Mathf.Clamp(timeToDisplay, 0, Mathf.Infinity);
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Returns the time already spent
    public float GetTimeSpent()
    {
        return 300f - timeRemaining;
    }

    public void ReduceTime(float penalty)
    {
        Debug.Log($"Reducing time by {penalty} seconds.");
        timeRemaining -= penalty;
        timeRemaining = Mathf.Clamp(timeRemaining, 0, Mathf.Infinity);
        DisplayTime(timeRemaining);
        Debug.Log($"Time remaining is now: {timeRemaining}");
    }
}