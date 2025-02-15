using UnityEngine;
using System.Collections;


public class FadeOut : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Call this method to fade out the UI or panel
    public void FadeOutPanel()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    // Coroutine for the fade-out effect
    private IEnumerator FadeOutCoroutine()
    {
        float duration = 1f;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0f; // Ensure it's fully transparent
    }
}
