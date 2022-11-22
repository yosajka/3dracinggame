using UnityEngine.UI;
using UnityEngine;

public class LapTimeCounter : MonoBehaviour
{
    public static float totalTime = 0;
    public static int minuteCount;
    public static int secondCount;
    public static bool isCountingTime;

    public static int bestMin;
    public static int bestSecond;

    public Text lapTimeDisplay;
    public Text lapBestDisplay;

    void Start()
    {
        bestMin = PlayerPrefs.GetInt("Track01LapBestMin", 0);
        bestSecond = PlayerPrefs.GetInt("Track01LapBestSecond", 1);
        
    }

    

    void UpdateTime()
    {
        totalTime += Time.deltaTime;
        minuteCount = Mathf.FloorToInt(totalTime / 60);
        secondCount = Mathf.FloorToInt(totalTime % 60);

        
        lapTimeDisplay.text = string.Format("{0:00}:{1:00}", minuteCount, secondCount);
        lapBestDisplay.text = string.Format("{0:00}:{1:00}", bestMin, bestSecond);
    }

    public static void UpdateBestLapTime()
    {
        bestMin = PlayerPrefs.GetInt("Track01LapBestMin", 0);
        bestSecond = PlayerPrefs.GetInt("Track01LapBestSecond", 1);
    }

    void Update()
    {
        if (isCountingTime)
        {
            UpdateTime();
        }
        
    }
}
