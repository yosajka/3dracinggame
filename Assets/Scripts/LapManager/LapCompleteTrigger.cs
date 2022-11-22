// This script is added to LapCompleteTrigger

using UnityEngine;

public class LapCompleteTrigger : MonoBehaviour
{
    public int numCheckpoints = 6;

    void OnTriggerEnter(Collider collider)
    {
        
        if (collider.CompareTag("Player"))
        {
            
            if (LapManager.currentCheckpoint == numCheckpoints)
            {
                LapManager.currentLap += 1;
                SaveLapBestTime();
                LapTimeCounter.totalTime = 0;
                LapManager.currentCheckpoint = 0;
            }
    
        }

        if (collider.CompareTag("CarAI"))
        {
            AI_LapManager CarAI = collider.gameObject.GetComponentInParent<AI_LapManager>();
            if (CarAI.currentCheckpoint == numCheckpoints)
            {
                CarAI.currentLap += 1;
                CarAI.currentCheckpoint = 0;
            }
            
        }
    }

    void SaveLapBestTime()
    {
        if (LapTimeCounter.bestMin == 0 && LapTimeCounter.bestSecond == 0)
        {
            PlayerPrefs.SetInt("Track01LapBestMin", LapTimeCounter.minuteCount);
            PlayerPrefs.SetInt("Track01LapBestSecond", LapTimeCounter.secondCount);
            LapTimeCounter.UpdateBestLapTime();
        }

        if (LapTimeCounter.minuteCount < LapTimeCounter.bestMin)
        {
            PlayerPrefs.SetInt("Track01LapBestMin", LapTimeCounter.minuteCount);
            PlayerPrefs.SetInt("Track01LapBestSecond", LapTimeCounter.secondCount);
            LapTimeCounter.UpdateBestLapTime();
        }

        else if (LapTimeCounter.minuteCount == LapTimeCounter.bestMin)
        {
            if (LapTimeCounter.secondCount < LapTimeCounter.bestSecond)
            {
                PlayerPrefs.SetInt("Track01LapBestMin", LapTimeCounter.minuteCount);
                PlayerPrefs.SetInt("Track01LapBestSecond", LapTimeCounter.secondCount);
            }
            LapTimeCounter.UpdateBestLapTime();
        }
    }
}
