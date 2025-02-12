using UnityEngine;

public class SlidePanel : MonoBehaviour
{
    private RectTransform rectTransform;
    public Vector2 hiddenPosition;
    public Vector2 shownPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = hiddenPosition; // Initially hidden
    }

    // Call this to slide the panel in
    public void SlideIn()
    {
        StartCoroutine(SlideCoroutine(shownPosition));
    }

    // Call this to slide the panel out
    public void SlideOut()
    {
        StartCoroutine(SlideCoroutine(hiddenPosition));
    }

    // Coroutine for sliding the panel to target position
    private IEnumerator SlideCoroutine(Vector2 targetPosition)
    {
        float duration = 0.5f;
        Vector2 startPosition = rectTransform.anchoredPosition;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = targetPosition;
    }
}
