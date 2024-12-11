using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the Game Over panel
    public PlayerController playerController; // Reference to PlayerController

    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // Ensure the Game Over Panel is hidden at the start
        }
        else
        {
            Debug.LogError("GameOverPanel is not assigned in the Inspector.");
        }
    }

    public void ShowGameOver()
    {
        Debug.Log("ShowGameOver called");

        if (playerController != null)
        {
            playerController.StopEngineAudio(); // Stop the engine audio
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Display the Game Over panel
        }

        Time.timeScale = 0; // Pause the game
    }

    public void RestartGame()
    {
        Debug.Log("RestartGame called");
        Time.timeScale = 1; // Resume game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
