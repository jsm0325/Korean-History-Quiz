using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResetRawImagePosition : MonoBehaviour
{
    // Duration for the movement
    public float duration = 2f;
    // Duration for the fade out
    public float fadeDuration = 1f;

    void Start()
    {
        // Start the coroutine to reset positions and fade out
        StartCoroutine(ResetPositionAndFadeOut());
    }

    IEnumerator ResetPositionAndFadeOut()
    {
        // Get all RawImage components in the Canvas except ThreeKey
        RawImage[] rawImages = GetComponentsInChildren<RawImage>();
        rawImages = System.Array.FindAll(rawImages, image => image.gameObject.name != "ThreeKey");

        // Record the initial positions and colors of the RawImages
        Vector3[] initialPositions = new Vector3[rawImages.Length];
        Color[] initialColors = new Color[rawImages.Length];
        for (int i = 0; i < rawImages.Length; i++)
        {
            initialPositions[i] = rawImages[i].rectTransform.localPosition;
            initialColors[i] = rawImages[i].color;
        }

        float elapsedTime = 0f;

        // Move the positions over the specified duration
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            for (int i = 0; i < rawImages.Length; i++)
            {
                rawImages[i].rectTransform.localPosition = Vector3.Lerp(initialPositions[i], Vector3.zero, t);
            }

            yield return null;
        }

        // Ensure all positions are exactly at (0, 0, 0) at the end
        for (int i = 0; i < rawImages.Length; i++)
        {
            rawImages[i].rectTransform.localPosition = Vector3.zero;
        }

        // Reset elapsed time for fading out
        elapsedTime = 0f;

        // Fade out the images
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;

            for (int i = 0; i < rawImages.Length; i++)
            {
                Color color = rawImages[i].color;
                color.a = Mathf.Lerp(initialColors[i].a, 0, t);
                rawImages[i].color = color;
            }

            yield return null;
        }

        // Ensure all alpha values are exactly 0 at the end
        for (int i = 0; i < rawImages.Length; i++)
        {
            Color color = rawImages[i].color;
            color.a = 0;
            rawImages[i].color = color;
        }

        // Start the coroutine to fade in ThreeKey image
        StartCoroutine(FadeInThreeKey());
    }

    IEnumerator FadeInThreeKey()
    {
        // Find the ThreeKey RawImage
        RawImage threeKeyImage = GameObject.Find("ThreeKey").GetComponent<RawImage>();
        Color initialColor = threeKeyImage.color;
        initialColor.a = 0;
        threeKeyImage.color = initialColor;

        float elapsedTime = 0f;

        // Fade in the ThreeKey image
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;

            Color color = threeKeyImage.color;
            color.a = Mathf.Lerp(0, 1, t);
            threeKeyImage.color = color;

            yield return null;
        }

        // Ensure the alpha value is exactly 1 at the end
        Color finalColor = threeKeyImage.color;
        finalColor.a = 1;
        threeKeyImage.color = finalColor;
    }
}
