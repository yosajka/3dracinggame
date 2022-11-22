using UnityEngine.UI;
using UnityEngine;

public class LapManager : MonoBehaviour
{

    public int totalLap = 3;
    public static int currentLap;
    public static int currentCheckpoint;
    public int lap;
    public int checkpoint;

    public Text lapDisplay;
    
    public Text positionDisplay;
    
    void Start()
    {
        currentLap = 1;
        currentCheckpoint = 0;
    }

    
    void Update()
    {
        lap = currentLap;
        checkpoint = currentCheckpoint;
        DisplayLapCounter();
        DisplayPosition();
    }

    void DisplayLapCounter()
    {
        lapDisplay.text = currentLap.ToString() + "/" + totalLap.ToString();
    }

    void DisplayPosition()
    {
        positionDisplay.text =PositionTracker.playerPosition.ToString() + "/" + "2";
    }
}
