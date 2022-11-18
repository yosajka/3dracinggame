using UnityEngine.UI;
using UnityEngine;

public class LapTimeCounter : MonoBehaviour
{
    public static float totalTime = 0;
    float minuteCount;
    float secondCount;
    public static bool isCountingTime;

    public Text lapTimeDisplay;

    void UpdateTime()
    {
        totalTime += Time.deltaTime;
        minuteCount = Mathf.FloorToInt(totalTime / 60);
        secondCount = Mathf.FloorToInt(totalTime % 60);

        lapTimeDisplay.text = string.Format("{0:00}:{1:00}", minuteCount, secondCount);
    }

    void Update()
    {
        if (isCountingTime)
        {
            UpdateTime();
        }
        
    }
}
