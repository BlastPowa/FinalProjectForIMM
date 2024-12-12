using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this for TextMeshPro support

public class Speedometer : MonoBehaviour
{
    public Rigidbody target; // Reference to the Rigidbody of the car
    public float maxSpeed = 50.0f; // Adjust this to your car's actual maximum speed in km/h
    public float minSpeedArrowAngle = -90.0f; // Minimum needle angle
    public float maxSpeedArrowAngle = 90.0f; // Maximum needle angle

    [Header("UI")]
    public TextMeshProUGUI speedLabel; // The text that displays the speed
    public RectTransform arrow; // The needle of the speedometer

    private float speed = 0.0f;

    private void Update()
    {
        if (target == null) return; // Ensure the target Rigidbody is assigned

        // Convert the car's velocity to km/h
        speed = target.velocity.magnitude * 3.6f;

        // Clamp the speed to the max speed
        speed = Mathf.Clamp(speed, 0, maxSpeed);

        // Update the speed label
        if (speedLabel != null)
            speedLabel.text = ((int)speed) + " km/h";

        // Rotate the needle based on the current speed
        if (arrow != null)
        {
            float needleAngle = Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed);
            arrow.localEulerAngles = new Vector3(0, 0, needleAngle);
        }
    }
}
