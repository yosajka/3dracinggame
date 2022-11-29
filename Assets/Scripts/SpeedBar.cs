using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{
    public GameObject player;
    public Image speedBar;

    [SerializeField]
    private float maxSpeed = 150;
    [SerializeField]
    private float speedValue;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        speedValue = player.GetComponent<RCC_CarControllerV3>().speed;
        SpeedChange();
    }

    void SpeedChange()
    {
        float amount = (speedValue/maxSpeed) * 0.5f;
        speedBar.fillAmount = amount;
    }
}
