using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Method to load the Maze scene (Build Index 1)
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // Load scene with Build Index 1
    }

    // Method to quit the application
    public void QuitGame()
    {
        Debug.Log("Quit Game"); 
        Application.Quit(); // Quit the application
    }
}