using UnityEngine;

// Camera Controller - Handles Different Views
public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float rotationSpeed = 5f;
    
    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
