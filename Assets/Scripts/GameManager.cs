using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseButton;         // The always‑visible Pause Button on your HUD
    public GameObject winUI;
    public GameObject lossUI;
    public GameObject pauseUI;             // Panel containing Resume and Quit buttons
    public FinalScoreDisplay finalScoreDisplay;
    private bool gameEnded = false;
    private bool gamePaused = false;       // Tracks whether the game is paused

    // Called when the player wins
    public void PlayerWins()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            Debug.Log("PlayerWins() invoked");

            // Hide the pause UI if it's active
            if (pauseUI != null)
            {
                pauseUI.SetActive(false);
                Debug.Log("PauseUI hidden.");
            }

            // Hide the pause button if it's active
            if (pauseButton != null)
            {
                pauseButton.SetActive(false);
                Debug.Log("PauseButton hidden.");
            }

            // Show the win UI
            winUI.SetActive(true);
            finalScoreDisplay.DisplayFinalScore();
            Time.timeScale = 0; // Stop the game
        }
    }

    // Called when the player loses
    public void PlayerLoses()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            if (pauseUI != null)
                pauseUI.SetActive(false);
            if (pauseButton != null)
                pauseButton.SetActive(false);
            lossUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // Pause the game and show the PauseUI panel
    public void PauseGame()
    {
        if (!gameEnded && !gamePaused)
        {
            gamePaused = true;
            if (pauseUI != null)
                pauseUI.SetActive(true);  // Display Resume and Quit buttons
            Time.timeScale = 0; // Freeze game time
        }
    }

    // Resume the game by hiding the PauseUI panel
    public void ResumeGame()
    {
        if (gamePaused)
        {
            gamePaused = false;
            if (pauseUI != null)
                pauseUI.SetActive(false);
            Time.timeScale = 1;  // Resume game time
        }
    }

    // Quit the game (or return to the main menu)
    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}