using UnityEngine;
using UnityEngine.UI; // For the Slider UI component

public class SensitivitySlider : MonoBehaviour
{
    public Slider sensitivitySlider; // Reference to the UI Slider
    public BallControl ballControl; // Reference to the BallControl script

    private void Start()
    {
        // Ensure slider and BallControl reference are set
        if (sensitivitySlider != null && ballControl != null)
        {
            // Set the slider initial value to match BallControl's sensitivity
            sensitivitySlider.value = ballControl.moveSpeedModifier;

            
            sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);
        }
        else
        {
            Debug.LogWarning("SensitivitySlider script: Missing references!");
        }
    }

    private void UpdateSensitivity(float newSensitivity)
    {
        if (ballControl != null)
        {
            // Update BallControl's sensitivity
            ballControl.moveSpeedModifier = newSensitivity;
            Debug.Log($"Sensitivity updated to: {newSensitivity}");
        }
    }
}