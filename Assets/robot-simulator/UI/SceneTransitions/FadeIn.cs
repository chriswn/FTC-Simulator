using UnityEngine;

public class FadeIn : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(FadeInCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        float duration = 1f; // Duration of the fade-in
        float timeElapsed = 0f;

        // Fade in animation
        while (timeElapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f; // Ensure it's fully visible
    }
}
