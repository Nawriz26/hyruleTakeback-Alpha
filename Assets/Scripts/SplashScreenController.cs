using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashScreenController : MonoBehaviour
{
    [SerializeField] private float displayDuration = 3f;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeInDuration = 1f;
    [SerializeField] private float fadeOutDuration = 1f;

    private void Start()
    {
        StartCoroutine(SplashSequence());
    }

    private IEnumerator SplashSequence()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;
            yield return FadeCanvasGroup(canvasGroup, 0f, 1f, fadeInDuration);
        }

        yield return new WaitForSeconds(displayDuration);

        if (canvasGroup != null)
        {
            yield return FadeCanvasGroup(canvasGroup, 1f, 0f, fadeOutDuration);
        }

        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            cg.alpha = Mathf.Lerp(start, end, elapsed / duration);
            yield return null;
        }
        cg.alpha = end;
    }
}
