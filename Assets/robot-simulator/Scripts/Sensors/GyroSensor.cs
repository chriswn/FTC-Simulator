using UnityEngine;

public class GyroSensor : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.Log("Robot Angular Velocity: " + rb.angularVelocity);
    }
}
