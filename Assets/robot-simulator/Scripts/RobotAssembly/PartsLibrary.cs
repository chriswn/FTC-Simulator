using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsLibrary : MonoBehaviour
{
    public List<GameObject> parts;
    public Transform partsPanel; // Assign in Unity Inspector
    public GameObject partButtonPrefab;

    void Start()
    {
        foreach (GameObject part in parts)
        {
            GameObject button = Instantiate(partButtonPrefab, partsPanel);
            button.GetComponentInChildren<Text>().text = part.name;
            button.GetComponent<Button>().onClick.AddListener(() => SelectPart(part));
        }
    }

    void SelectPart(GameObject part)
    {
        FindObjectOfType<RobotBuilder>().SelectPart(part);
    }
}
