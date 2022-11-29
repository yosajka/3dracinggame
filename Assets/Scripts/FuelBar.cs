using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public GameObject player;
    public Image fuelBar;
    public GameObject warningText;

    [SerializeField]
    private float fuelCapacity;
    [SerializeField]
    private float fuelValue;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fuelCapacity = player.GetComponent<RCC_CarControllerV3>().fuelTankCapacity;
    }

    
    void Update()
    {
        fuelValue = player.GetComponent<RCC_CarControllerV3>().fuelTank;
        SpeedChange();

        if (fuelValue <= 0)
        {
            warningText.SetActive(true);
            player.GetComponent<RCC_CarControllerV3>().canControl = false;
            //player.GetComponent<RCC_CarControllerV3>().speed -= 10;
            // if (player.GetComponent<RCC_CarControllerV3>().speed <= 0)
            // {
            //     player.GetComponent<RCC_CarControllerV3>().speed = 0;
            // }
        }
        else
        {
            warningText.SetActive(false);
            player.GetComponent<RCC_CarControllerV3>().canControl = true;
        }
    }

    void SpeedChange()
    {
        float amount = (fuelValue/fuelCapacity) * 0.5f;
        fuelBar.fillAmount = amount;
    }
}
