using System.Collections;
using UnityEngine;
using TMPro;

public class FadingText : MonoBehaviour
{
    [Header("Fade Settings")]
    [Tooltip("Duration of the fade in seconds. Lower # fade fasteer, higher numbers fade slower.")]
    public float fadeDuration = 2.0f;
    private TMP_Text textComponent;

    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    //Starts the smooth fade process
    public void FadeAndHide()
    {
        StartCoroutine(FadeOutRoutine(fadeDuration));
    }

    private IEnumerator FadeOutRoutine(float duration)
    {
        Color originalColor = textComponent.color;
        float startAlpha = originalColor.a;

        for (float elapsed = 0; elapsed < duration; elapsed += Time.deltaTime)
        {
            float normalizedTime = elapsed / duration;
            Color newColor = originalColor;
            newColor.a = Mathf.Lerp(startAlpha, 0f, normalizedTime);
            textComponent.color = newColor;
            yield return null; //waiting for the next frame
        }

        //Disable object once fully transparent
        gameObject.SetActive(false);
    }
}