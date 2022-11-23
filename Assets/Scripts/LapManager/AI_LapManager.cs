using UnityEngine;

public class AI_LapManager : MonoBehaviour
{
    
    public int totalLap = 3;
    public int currentLap;
    public int currentCheckpoint;
    public int currentPosition;

    
    
    void Start()
    {
        
        currentLap = 1;
        currentCheckpoint = 0;
    }

}
