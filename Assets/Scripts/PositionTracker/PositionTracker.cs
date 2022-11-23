using UnityEngine;

public class PositionTracker : MonoBehaviour
{
    public GameObject playerCar;
    public GameObject[] CarAIs;
    public GameObject[] Checkpoints;

    public bool[] isAheadOf;

    public static int maxPosition;
    
    void Start()
    {
        maxPosition = CarAIs.Length + 1;
        
    }

    
    void Update()
    {

        CalculatePosition();

        playerCar.GetComponent<LapManager>().currentPosition = DeterminePosition(isAheadOf);
    }

    private int DeterminePosition(bool[] isAheadOf)
    {
        int position = maxPosition;
        for (int i = 0; i < isAheadOf.Length; i++)
        {
            if (isAheadOf[i])
            {
                position -= 1;
            }
        }

        return position;
    }
    private void CalculatePosition()
    {
        int playerCurrentLap = LapManager.currentLap;
        int playerCurrentCheckpoint = LapManager.currentCheckpoint;
        float playerNextCheckpointDistance;

        GameObject playerNextCheckpoint;
        if (playerCurrentCheckpoint == 6)
        {
            playerNextCheckpoint = Checkpoints[0];
        }
        else
        {
            playerNextCheckpoint = Checkpoints[playerCurrentCheckpoint + 1];
        }
        
        playerNextCheckpointDistance = CalculateDistance(playerCar.transform.position, playerNextCheckpoint.transform.position);
        
        

        for (int i = 0; i < CarAIs.Length; i++)
        {
            int aiCurrentLap = CarAIs[i].GetComponent<AI_LapManager>().currentLap;

            if (playerCurrentLap > aiCurrentLap)
            {
                isAheadOf[i] = true;
            }
            else if (playerCurrentLap < aiCurrentLap)
            {
               isAheadOf[i] = false;
            }
            else
            {
                int aiCurrentCheckpoint = CarAIs[i].GetComponent<AI_LapManager>().currentCheckpoint;

                if (playerCurrentCheckpoint > aiCurrentCheckpoint)
                {
                    isAheadOf[i] = true;
                }
                else if (playerCurrentCheckpoint < aiCurrentCheckpoint)
                {
                    isAheadOf[i] = false;
                }
                else
                {
                    float aiNextCheckpointDistance;
                    
                    GameObject aiNextCheckpointObject;

                    if (aiCurrentCheckpoint == 6)
                    {
                        aiNextCheckpointObject = Checkpoints[0];
                    }
                    else
                    {
                        aiNextCheckpointObject = Checkpoints[aiCurrentCheckpoint + 1];
                    }

                    aiNextCheckpointDistance = CalculateDistance(CarAIs[i].transform.position, aiNextCheckpointObject.transform.position);
                    

                    if (playerNextCheckpointDistance <= aiNextCheckpointDistance)
                    {
                        isAheadOf[i] = true;
                    }
                    else
                    {
                        isAheadOf[i] = false;
                    }
                }
            }
        }
    }

    private float CalculateDistance(Vector3 carPosition, Vector3 checkpointPosition)
    {
        float distance = Vector3.Distance(carPosition, checkpointPosition);
        return distance;
    }
}
