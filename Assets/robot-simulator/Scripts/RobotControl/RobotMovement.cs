using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider backLeftWheel;
    public WheelCollider backRightWheel;

    public float motorTorque = 150f;
    public float maxSpeed = 10f;
    public float turnSpeed = 50f;  // Adjust for sharper turns
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 15f;  // Simulate realistic weight
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");  // Forward/Backward (W/S or Up/Down)
        float turnInput = Input.GetAxis("Horizontal");  // Turning (A/D or Left/Right)

        MoveRobot(moveInput, turnInput);
    }

    public void MoveRobot(float moveInput, float turnInput)
    {
        if (rb.velocity.magnitude < maxSpeed || moveInput < 0)  // Prevent excessive speed
        {
            // Apply torque for forward/backward movement
            frontLeftWheel.motorTorque = motorTorque * moveInput;
            frontRightWheel.motorTorque = motorTorque * moveInput;
            backLeftWheel.motorTorque = motorTorque * moveInput;
            backRightWheel.motorTorque = motorTorque * moveInput;
        }

        // Implement Tank Drive: Turn by applying different power to wheels
        frontLeftWheel.steerAngle = 0; // No need for steering angle in tank drive
        frontRightWheel.steerAngle = 0;

        frontLeftWheel.motorTorque += turnSpeed * turnInput;
        backLeftWheel.motorTorque += turnSpeed * turnInput;
        frontRightWheel.motorTorque -= turnSpeed * turnInput;
        backRightWheel.motorTorque -= turnSpeed * turnInput;

        // Apply brake only if no movement
        if (Mathf.Abs(moveInput) < 0.1f && Mathf.Abs(turnInput) < 0.1f)
        {
            ApplyBrakes(100f);
        }
        else
        {
            ApplyBrakes(0f);
        }
    }

    private void ApplyBrakes(float brakeForce)
    {
        frontLeftWheel.brakeTorque = brakeForce;
        frontRightWheel.brakeTorque = brakeForce;
        backLeftWheel.brakeTorque = brakeForce;
        backRightWheel.brakeTorque = brakeForce;
    }
}
