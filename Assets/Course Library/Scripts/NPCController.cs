using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float speed = 10.0f; // Speed of the NPC car
    private GameOverManager gameOverManager; // Reference to the Game Over Manager

    void Start()
    {
        // Find and assign the GameOverManager in the scene
        gameOverManager = GameObject.FindObjectOfType<GameOverManager>();

        if (gameOverManager == null)
        {
            Debug.LogError("GameOverManager not found in the scene.");
        }
    }

    void Update()
    {
        // Move the NPC forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over! You hit an NPC car.");

            // Trigger the Game Over screen via the GameOverManager
            if (gameOverManager != null)
            {
                gameOverManager.ShowGameOver();
            }
            else
            {
                Debug.LogError("GameOverManager is not assigned.");
            }
        }
    }
}
