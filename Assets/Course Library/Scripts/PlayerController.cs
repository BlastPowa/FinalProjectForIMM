using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 60.0f;
    public GameOverManager gameOverManager; // Reference to Game Over Manager

    private AudioSource[] audioSources;
    private AudioSource startupAudio;
    private AudioSource engineAudio;
    private bool isMoving = false;

    void Start()
    {
        audioSources = GetComponents<AudioSource>();

        if (audioSources.Length >= 2)
        {
            startupAudio = audioSources[0];
            engineAudio = audioSources[1];

            // Adjust engine volume
            engineAudio.volume = 0.3f; // Lower the volume
        }

        if (startupAudio != null)
        {
            startupAudio.Play();
        }
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        if (Mathf.Abs(verticalInput) > 0 || Mathf.Abs(horizontalInput) > 0)
        {
            if (!isMoving && engineAudio != null)
            {
                engineAudio.Play();
                isMoving = true;
            }
        }
        else
        {
            if (isMoving && engineAudio != null)
            {
                engineAudio.Pause();
                isMoving = false;
            }
        }
    }

    public void StopEngineAudio()
    {
        if (engineAudio != null)
        {
            engineAudio.Stop(); // Stop the engine audio
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over! Collided with: " + collision.gameObject.name);
            gameOverManager.ShowGameOver(); // Trigger Game Over
        }
    }
}
