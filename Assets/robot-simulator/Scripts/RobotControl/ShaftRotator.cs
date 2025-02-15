using UnityEngine;

public class ShaftRotator : MonoBehaviour
{
    public float maxRPM = 6000f;
    public float power = 0f;
    public bool reverse = false;
    public Transform shaftTransform;

    private float currentRPM = 0f;

    void Update()
    {
        // Calculate target RPM
        float targetRPM = power * maxRPM * (reverse ? -1 : 1);
        currentRPM = Mathf.Lerp(currentRPM, targetRPM, Time.deltaTime * 5f);

        // Convert RPM to degrees per second
        float degreesPerSecond = (currentRPM / 60f) * 360f;

        if (shaftTransform != null && power != 0f)
        {
            // Rotate around the shaft's current position using its UP (Y) axis
            shaftTransform.RotateAround(
                shaftTransform.position,      // Pivot point (shaft's own position)
                shaftTransform.up,           // Axis (local Y-axis)
                degreesPerSecond * Time.deltaTime
            );
        }
    }

    public void SetPower(float newPower)
    {
        power = Mathf.Clamp(newPower, -1f, 1f);
    }
}