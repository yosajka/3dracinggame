using UnityEngine;

public class HalfLapCheckPoint : MonoBehaviour
{
    public GameObject lapCompleteTrigger;

    void OnTriggerEnter(Collider collider)
    {
        
        if (collider.CompareTag("Player"))
        {
            //Debug.Log("collided");
            GetComponent<BoxCollider>().enabled = false;
            lapCompleteTrigger.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
