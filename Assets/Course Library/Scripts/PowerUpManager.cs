using System.Collections;
using UnityEngine;
using TMPro;

public class PowerUpManager : MonoBehaviour
{
    private int score = 0; // Player's score
    public TextMeshProUGUI scoreText; // Reference to the Score Text UI
    public PlayerController playerController; // Reference to the PlayerController script

    void Start()
    {
        // Automatically find the ScoreText object in the scene
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
        }

        if (scoreText == null)
        {
            Debug.LogError("ScoreText is not assigned or not found in the scene.");
        }
        else
        {
            scoreText.text = "Score: 0"; // Initialize the score display
        }

        // Automatically find the PlayerController object in the scene
        if (playerController == null)
        {
            playerController = GameObject.FindObjectOfType<PlayerController>();
            if (playerController == null)
            {
                Debug.LogError("PlayerController is not assigned or found in the scene.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check the tag of the collided object and perform actions accordingly
        if (other.CompareTag("Coin"))
        {
            CollectCoin();
            Destroy(other.gameObject); // Remove the coin after collection
        }
        else if (other.CompareTag("Star"))
        {
            CollectStar();
            Destroy(other.gameObject); // Remove the star after collection
        }
        else if (other.CompareTag("Boost"))
        {
            StartCoroutine(ApplySpeedBoost(1.5f, 5f)); // Apply a 1.5x speed boost for 5 seconds
            Destroy(other.gameObject); // Remove the boost after collection
}
        else if (other.CompareTag("Rocket"))
{
            StartCoroutine(ApplySpeedBoost(2.0f, 5f)); // Apply a 2.0x speed boost for 5 seconds
             Destroy(other.gameObject); // Remove the rocket after collection
}

    }

    public void CollectCoin()
    {
        // Increment the score by 1
        score += 1;
        Debug.Log("Coin collected! Current score: " + score);

        // Update the score text in the UI
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void CollectStar()
    {
        // Increment the score by 50
        score += 50;
        Debug.Log("Star collected! Current score: " + score);

        // Update the score text in the UI
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private IEnumerator ApplySpeedBoost(float speedMultiplier, float duration)
    {
        Debug.Log("Speed boost activated! Multiplier: " + speedMultiplier);

        // Temporarily increase the player's speed
        if (playerController != null)
        {
            playerController.speed *= speedMultiplier;
        }

        // Wait for the duration of the boost
        yield return new WaitForSeconds(duration);

        // Reset the player's speed
        if (playerController != null)
        {
            playerController.speed /= speedMultiplier;
        }

        Debug.Log("Speed boost ended.");
    }

    public int GetScore()
    {
        // Return the player's current score
        return score;
    }
}
