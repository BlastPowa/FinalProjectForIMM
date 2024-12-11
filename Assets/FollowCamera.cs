using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;      // The car the camera will follow
    public Vector3 offset = new Vector3(0, 5, -10); // Offset from the car
    public float smoothSpeed = 0.125f; // Smoothness of camera movement

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position of the camera
            Vector3 desiredPosition = target.position + offset;
            
            // Smoothly interpolate the camera's position to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Optionally, make the camera look at the car
            transform.LookAt(target);
        }
    }
}
