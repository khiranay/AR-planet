using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// 
/// Tambahkan ke QuizPanel untuk animasi muncul/fade soal.
///
public class UIAnimator : MonoBehaviour
{
    [Header("Question Card")]
    public CanvasGroup questionCard;
    public float fadeDuration = 0.3f;

    public void AnimateIn()
    {
        StopAllCoroutines();
        StartCoroutine(FadeCanvasGroup(questionCard, 0f, 1f, fadeDuration));
    }

    public void AnimateOut()
    {
        StopAllCoroutines();
        StartCoroutine(FadeCanvasGroup(questionCard, 1f, 0f, fadeDuration));
    }

    IEnumerator FadeCanvasGroup(CanvasGroup cg, float from, float to, float duration)
    {
        float elapsed = 0f;
        cg.alpha = from;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            cg.alpha = Mathf.Lerp(from, to, elapsed / duration);
            yield return null;
        }
        cg.alpha = to;
    }
}