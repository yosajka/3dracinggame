using UnityEngine.UI;
using UnityEngine;

public class TotalTimeCounter : MonoBehaviour
{
    public static float totalTime = 0;
    float minuteCount;
    float secondCount;
    public static bool isCountingTime;

    public Text totalTimeDisplay;

    void UpdateTime()
    {
        totalTime += Time.deltaTime;
        minuteCount = Mathf.FloorToInt(totalTime / 60);
        secondCount = Mathf.FloorToInt(totalTime % 60);

        totalTimeDisplay.text = string.Format("{0:00}:{1:00}", minuteCount, secondCount);
    }

    void Update()
    {
        if (isCountingTime)
        {
            UpdateTime();
        }        
    }
}
