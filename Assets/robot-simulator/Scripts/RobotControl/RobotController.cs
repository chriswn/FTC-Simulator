using UnityEngine;

public class RobotController : MonoBehaviour
{
    public RobotMovement robotMovement;  // Link the RobotMovement script
    private FTCClient ftcClient;  // Link FTC communication

    void Start()
    {
        // Use FindFirstObjectByType instead of deprecated FindObjectOfType
        ftcClient = FindFirstObjectByType<FTCClient>();

        if (robotMovement == null)
        {
            Debug.LogError("RobotMovement script is not assigned in the inspector!");
        }

        if (ftcClient == null)
        {
            Debug.LogError("FTCClient script not found in the scene!");
        }
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");  // W/S keys for forward/backward
        float turnInput = Input.GetAxis("Horizontal");   // A/D keys for turning

        if (robotMovement != null)
        {
            robotMovement.MoveRobot(forwardInput, turnInput);
        }

        if (ftcClient != null)
        {
            HandleFTCCommands();
        }
    }

    void HandleFTCCommands()
    {
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
