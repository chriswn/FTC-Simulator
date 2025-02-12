using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Call this method when transitioning to another scene
    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    // Coroutine to fade out and load the next scene
    private IEnumerator FadeOut(string sceneName)
    {
        float duration = 1f;
        float timeElapsed = 0f;

        // Fade out animation
        while (timeElapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0f; // Ensure it's fully invisible
        SceneManager.LoadScene(sceneName); // Load the next scene
    }
}
