using System.Collections;
using UnityEngine;
using TMPro;

public class InstructionManager : MonoBehaviour
{
    public TextMeshProUGUI instructionText; // Reference to the Instruction Text
    public float displayDuration = 3.0f;   // Duration to show the text (in seconds)

    void Start()
    {
        if (instructionText != null)
        {
            StartCoroutine(HideInstructionAfterDelay());
        }
        else
        {
            Debug.LogError("InstructionText is not assigned in the Inspector.");
        }
    }

    private IEnumerator HideInstructionAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);

        if (instructionText != null)
        {
            instructionText.gameObject.SetActive(false); // Hide the text
        }
    }
}
