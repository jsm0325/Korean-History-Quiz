using UnityEngine;
using UnityEngine.UI;

public class BlinkingImage : MonoBehaviour
{
    public RawImage rawImage;
    public float blinkDuration = 1f;
    public float maxAlpha = 0.5f;

    private float timer = 0f;
    private bool increasing = true;

    void Update()
    {
        timer += Time.deltaTime;
        float alpha = Mathf.Lerp(0f, maxAlpha, timer / blinkDuration);

        if (increasing)
        {
            if (timer >= blinkDuration)
            {
                timer = 0f;
                increasing = false;
            }
        }
        else
        {
            alpha = maxAlpha - alpha;
            if (timer >= blinkDuration)
            {
                timer = 0f;
                increasing = true;
            }
        }

        SetImageAlpha(alpha);
    }

    void SetImageAlpha(float alpha)
    {
        Color color = rawImage.color;
        color.a = alpha;
        rawImage.color = color;
    }
}
