using UnityEngine;

public class ObjectBounce : MonoBehaviour
{
    public float bounceHeight = 0.5f; // How high the object bounces
    public float bounceSpeed = 2f;   // How fast the object bounces

    private Vector3 initialPosition; // Store the object's initial position

    void Start()
    {
        // Record the starting position
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position
        float newY = initialPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;

        // Apply the updated position
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }
}
