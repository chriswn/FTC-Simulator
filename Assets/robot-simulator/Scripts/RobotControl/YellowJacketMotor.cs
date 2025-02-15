using UnityEngine;

public class YellowJacketMotor : MonoBehaviour
{
    public float maxRPM = 6000f; // Max speed of the motor
    public float power = 0f; // Motor power (-1 to 1)
    public float torque = 0.2f; // Simulated torque (arbitrary value)
    public bool reverse = false; // Reverse motor direction

    private float currentRPM = 0f;
    private float encoderTicks = 0f; // Simulated encoder value
    private Rigidbody rb;

    private const float encoderTicksPerRev = 560f; // Approximate ticks per revolution

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found! Attach this script to a GameObject with a Rigidbody.");
        }
    }

    void FixedUpdate()
    {
        // Calculate target RPM based on power
        float targetRPM = power * maxRPM * (reverse ? -1 : 1);

        // Smoothly adjust current RPM
        currentRPM = Mathf.Lerp(currentRPM, targetRPM, Time.deltaTime * 5f);

        // Convert RPM to angular velocity (radians per second)
        float angularVelocity = (currentRPM / 60f) * (2f * Mathf.PI);

        // Apply torque to the rigidbody
        if (rb != null)
        {
            rb.AddTorque(transform.up * torque * power, ForceMode.Force);
        }

        // Simulate encoder ticks
        encoderTicks += (currentRPM / 60f) * encoderTicksPerRev * Time.deltaTime;
    }

    public float GetRPM()
    {
        return currentRPM;
    }

    public float GetEncoderTicks()
    {
        return encoderTicks;
    }

    public void SetPower(float newPower)
    {
        power = Mathf.Clamp(newPower, -1f, 1f);
    }
}
