using UnityEngine;
using UnityEngine.UI;

public class SensorDisplay : MonoBehaviour
{
    public Text sensorText; // Reference to the UI Text component

    // Update the sensor data with animation
    public void UpdateSensorData(float sensorValue)
    {
        StartCoroutine(AnimateSensorData(sensorValue));
    }

    // Coroutine to animate sensor data updates
    private IEnumerator AnimateSensorData(float targetValue)
    {
        float currentValue = float.Parse(sensorText.text);
        float duration = 1f; // Animation duration
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            sensorText.text = Mathf.Lerp(currentValue, targetValue, timeElapsed / duration).ToString("F2");
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        sensorText.text = targetValue.ToString("F2"); // Final value
    }
}
