using UnityEngine;

public class DistanceSensor : MonoBehaviour
{
    public float sensorRange = 50f;
    
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, sensorRange))
        {
            Debug.Log("Obstacle detected at: " + hit.distance + " meters");
        }
    }
}
