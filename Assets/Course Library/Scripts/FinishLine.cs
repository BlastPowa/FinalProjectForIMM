using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public GameObject finishGamePanel; // Reference to the Finish Game UI Panel
    public TextMeshProUGUI finalScoreText; // Reference to the Final Score Text
    private PowerUpManager powerUpManager; // Reference to the PowerUpManager script

    void Start()
    {
        powerUpManager = GameObject.FindObjectOfType<PowerUpManager>();

        if (finishGamePanel != null)
        {
            finishGamePanel.SetActive(false); // Ensure the panel is hidden at the start
        }
        else
        {
            Debug.LogError("FinishGamePanel not assigned in the Inspector.");
        }

        if (finalScoreText == null)
        {
            Debug.LogError("FinalScoreText not assigned in the Inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        if (finishGamePanel != null)
        {
            finishGamePanel.SetActive(true); // Show the Finish Game Panel
        }

        if (finalScoreText != null && powerUpManager != null)
        {
            finalScoreText.text = "Your Score: " + powerUpManager.GetScore(); // Update the Final Score Text
        }

        Time.timeScale = 0; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
