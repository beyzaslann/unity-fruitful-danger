using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelLabelController : MonoBehaviour
{
    public RectTransform levelLabelRect;
    public Text levelLabelText;
    public Vector2 targetAnchor = new Vector2(1, 1);
    public Vector2 targetPosition = new Vector2(-50, -50);
    public float targetScale = 0.3f;
    public float moveDuration = 1f;
    public float displayTime = 3f;

    private Vector2 originalAnchor;
    private Vector2 originalPosition;
    private Vector3 originalScale;

    private void Start()
    {
        originalAnchor = levelLabelRect.anchorMin;
        originalPosition = levelLabelRect.anchoredPosition;
        originalScale = levelLabelRect.localScale;

        StartCoroutine(AnimateLabel());
    }

    IEnumerator AnimateLabel()
    {
        levelLabelRect.anchorMin = levelLabelRect.anchorMax = new Vector2(0.5f, 0.5f);
        levelLabelRect.anchoredPosition = Vector2.zero;
        levelLabelRect.localScale = Vector3.one;
        levelLabelText.enabled = true;

        yield return new WaitForSeconds(displayTime);

        float elapsed = 0f;

        Vector2 startAnchor = levelLabelRect.anchorMin;
        Vector2 endAnchor = targetAnchor;

        Vector2 startPos = levelLabelRect.anchoredPosition;
        Vector2 endPos = targetPosition;

        Vector3 startScale = levelLabelRect.localScale;
        Vector3 endScale = Vector3.one * targetScale;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / moveDuration);

            levelLabelRect.anchorMin = Vector2.Lerp(startAnchor, endAnchor, t);
            levelLabelRect.anchorMax = levelLabelRect.anchorMin;

            levelLabelRect.anchoredPosition = Vector2.Lerp(startPos, endPos, t);
            levelLabelRect.localScale = Vector3.Lerp(startScale, endScale, t);

            yield return null;
        }

        levelLabelRect.anchorMin = levelLabelRect.anchorMax = targetAnchor;
        levelLabelRect.anchoredPosition = targetPosition;
        levelLabelRect.localScale = Vector3.one * targetScale;

    }
}
