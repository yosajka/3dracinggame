using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    // add this script to every checkpoint except startline
    void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("CarAI"))
        {
            AI_LapManager CarAI = collider.gameObject.GetComponentInParent<AI_LapManager>();

            if (gameObject.name == "Checkpoint01")
            {
                CarAI.currentCheckpoint = 1;
            }
            else if (gameObject.name == "Checkpoint02")
            {
                CarAI.currentCheckpoint = 2;
            }
            else if (gameObject.name == "Checkpoint03")
            {
                CarAI.currentCheckpoint = 3;
            }
            else if (gameObject.name == "Checkpoint04")
            {
                CarAI.currentCheckpoint = 4;
            }
            else if (gameObject.name == "Checkpoint05" && CarAI.currentCheckpoint == 4)
            {
                CarAI.currentCheckpoint = 5;
            }
            else if (gameObject.name == "Checkpoint06" && CarAI.currentCheckpoint == 5)
            {
                CarAI.currentCheckpoint = 6;
            }
            
            
        }

        if (collider.CompareTag("Player"))
        {
            
            if (gameObject.name == "Checkpoint01")
            {
                LapManager.currentCheckpoint = 1;
            }
            else if (gameObject.name == "Checkpoint02")
            {
                LapManager.currentCheckpoint = 2;
            }
            else if (gameObject.name == "Checkpoint03")
            {
                LapManager.currentCheckpoint = 3;
            }
            else if (gameObject.name == "Checkpoint04")
            {
                LapManager.currentCheckpoint = 4;
            }
            else if (gameObject.name == "Checkpoint05" && LapManager.currentCheckpoint == 4)
            {
                LapManager.currentCheckpoint = 5;
            }
            else if (gameObject.name == "Checkpoint06" && LapManager.currentCheckpoint == 5)
            {
                LapManager.currentCheckpoint = 6;
            }
        }
    }
    
}
