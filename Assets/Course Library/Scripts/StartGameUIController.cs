using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameUIController : MonoBehaviour
{
    public GameObject StartGamePanel; // Reference to the Play Game panel
    public Button playButton;        // Reference to the Play Game button

    void Start()
    {
        // Ensure the Play Game panel is active at the start
        if (StartGamePanel != null)
        {
            StartGamePanel.SetActive(true);
        }

        // Add listener for the Play Game button
        if (playButton != null)
        {
            playButton.onClick.AddListener(StartGame);
        }

        // Pause the game at the start
        Time.timeScale = 0;
    }

    void StartGame()
    {
        // Hide the Play Game panel and all its children (including the button)
        if (StartGamePanel != null)
        {
            StartGamePanel.SetActive(false);
        }

        // Resume the game
        Time.timeScale = 1;
    }
}
