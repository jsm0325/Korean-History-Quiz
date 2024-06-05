using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    public Text timerText;
    private float elapsedTime = 0f;
    private bool isRunning = false;

    void Start()
    {
        // 스톱워치 시작
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimer(elapsedTime);
        }
    }

    void UpdateTimer(float currentTime)
    {
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartStopwatch()
    {
        isRunning = true;
        elapsedTime = 0f;
    }

    public void StopStopwatch()
    {
        isRunning = false;
    }

    public void ResetStopwatch()
    {
        elapsedTime = 0f;
        UpdateTimer(elapsedTime);
    }
}
