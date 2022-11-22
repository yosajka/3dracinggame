using UnityEngine;

public class PositionTracker : MonoBehaviour
{
    public GameObject playerCar;
    public GameObject[] CarAIs;
    public GameObject[] Checkpoints;

    public static int playerPosition;
    public int position;
    
    void Start()
    {
        playerPosition = CarAIs.Length + 1;
    }

    
    void Update()
    {
        position = playerPosition;

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
                playerPosition -= 1;
            }
            else if (playerCurrentLap < aiCurrentLap)
            {
                playerPosition += 1;
            }
            else
            {
                int aiCurrentCheckpoint = CarAIs[i].GetComponent<AI_LapManager>().currentCheckpoint;

                if (playerCurrentCheckpoint > aiCurrentCheckpoint)
                {
                    playerPosition -= 1;
                }
                else if (playerCurrentCheckpoint < aiCurrentCheckpoint)
                {
                    playerPosition += 1;
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
                        playerPosition -= 1;
                    }
                    else
                    {
                        playerPosition += 1;
                    }

                    
                }
            }

            playerPosition = Mathf.Max(1, playerPosition);
            playerPosition = Mathf.Min(CarAIs.Length + 1, playerPosition);
        }
    }

    private float CalculateDistance(Vector3 carPosition, Vector3 checkpointPosition)
    {
        float distance = Vector3.Distance(carPosition, checkpointPosition);
        return distance;
    }
}
