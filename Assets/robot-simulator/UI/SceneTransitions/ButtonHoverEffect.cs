using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform buttonRect;
    private Button button;
    private Color originalColor;
    private Color hoverColor = Color.cyan; // Set hover color (cyan for example)

    void Start()
    {
        buttonRect = GetComponent<RectTransform>();
        button = GetComponent<Button>();
        originalColor = button.image.color;
    }

    // Called when the user hovers over the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonRect.localScale = new Vector3(1.1f, 1.1f, 1); // Scale up on hover
        button.image.color = hoverColor; // Change button color
    }

    // Called when the user stops hovering over the button
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonRect.localScale = new Vector3(1f, 1f, 1); // Scale back to normal
        button.image.color = originalColor; // Reset to original color
    }

    // Called when the button is pressed
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonRect.localScale = new Vector3(0.9f, 0.9f, 1); // Shrink on press
    }

    // Called when the button press is released
    public void OnPointerUp(PointerEventData eventData)
    {
        buttonRect.localScale = new Vector3(1f, 1f, 1); // Reset to normal size
    }
}
