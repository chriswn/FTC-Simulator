using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RobotBuilder : MonoBehaviour
{
    public Transform chassis; // The base of the robot
    public List<GameObject> availableParts;
    public GameObject selectedPart;
    private GameObject previewPart;
    
    void Update()
    {
        if (selectedPart != null)
        {
            FollowMouse();
            if (Input.GetMouseButtonDown(0)) // Left Click to place part
            {
                PlacePart();
            }
        }
    }

    public void SelectPart(GameObject partPrefab)
    {
        if (previewPart != null) Destroy(previewPart);
        selectedPart = partPrefab;
        previewPart = Instantiate(selectedPart);
        previewPart.GetComponent<Collider>().enabled = false; // Disable physics until placed
    }

    void FollowMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            previewPart.transform.position = hit.point;
        }
    }

    void PlacePart()
    {
        if (previewPart != null)
        {
            previewPart.GetComponent<Collider>().enabled = true; // Enable physics
            previewPart = null;
            selectedPart = null;
        }
    }

    void PlacePart()
{
    if (previewPart != null)
    {
        Transform snapPoint = FindClosestSnapPoint(previewPart.transform.position);
        if (snapPoint != null)
        {
            previewPart.transform.position = snapPoint.position;
            previewPart.transform.rotation = snapPoint.rotation;
        }
        
        previewPart.GetComponent<Collider>().enabled = true;
        previewPart = null;
        selectedPart = null;
    }
}

Transform FindClosestSnapPoint(Vector3 position)
{
    float minDistance = float.MaxValue;
    Transform closest = null;

    foreach (Transform snapPoint in chassis.GetComponentsInChildren<Transform>())
    {
        float distance = Vector3.Distance(position, snapPoint.position);
        if (distance < minDistance && distance < 0.2f) // 0.2 = snap range
        {
            minDistance = distance;
            closest = snapPoint;
        }
    }
    return closest;
}

}
