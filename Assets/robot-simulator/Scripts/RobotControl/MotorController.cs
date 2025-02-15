using UnityEngine;

public class MotorController : MonoBehaviour
{
    public YellowJacketMotor motor;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            motor.SetPower(1f); // Full power forward
        else if (Input.GetKey(KeyCode.S))
            motor.SetPower(-1f); // Full power reverse
        else
            motor.SetPower(0f); // Stop

        Debug.Log("RPM: " + motor.GetRPM() + " | Encoder: " + motor.GetEncoderTicks());
    }
}

