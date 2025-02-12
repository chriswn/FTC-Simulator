using UnityEngine;

public class RobotController : MonoBehaviour
{
    public RobotMovement robotMovement;  // Link the RobotMovement script
    private FTCClient ftcClient;  // Link FTC communication

    void Start()
    {
        ftcClient = FindObjectOfType<FTCClient>();
    }

    void Update()
    {
        // Local Unity Movement (for physics-based movement)
        float forwardInput = Input.GetAxis("Vertical");  // W/S keys for forward/backward
        float turnInput = Input.GetAxis("Horizontal");   // A/D keys for turning

        robotMovement.MoveRobot(forwardInput);
        robotMovement.TurnRobot(turnInput);

        // Send Commands to FTC Java
        if (Input.GetKeyDown(KeyCode.W))
        {
            ftcClient.SendCommand("MOVE_FORWARD");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            ftcClient.SendCommand("TURN_LEFT");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ftcClient.SendCommand("TURN_RIGHT");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ftcClient.SendCommand("STOP");
        }

        // Display sensor data from FTC Java
        Debug.Log($"Gyro: {ftcClient.gyroData}, Distance: {ftcClient.distanceData}");
    }
}
