using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class StartCoundown : MonoBehaviour
{
    public Text countDownDisplay;
    public AudioSource countDownSound;
    public AudioSource goSound;

    public GameObject playerCar;
    public GameObject[] aICars;

    void Start()
    {
        StartCoroutine(CountDown());
    }

    
    IEnumerator CountDown()
    {
        countDownDisplay.text = "3";
        countDownSound.Play();
        yield return new WaitForSeconds(1f);
        countDownDisplay.text = "2";
        countDownSound.Play();
        yield return new WaitForSeconds(1f);
        countDownDisplay.text = "1";
        countDownSound.Play();
        yield return new WaitForSeconds(1f);
        countDownDisplay.text = "GO!";
        goSound.Play();
        yield return new WaitForSeconds(0.5f);
        countDownDisplay.enabled = false;
        LapTimeCounter.isCountingTime = true;
        TotalTimeCounter.isCountingTime = true;

        playerCar.GetComponent<RCC_CarControllerV3>().canControl = true;
        for (int i = 0; i < aICars.Length; i++)
        {
            aICars[i].GetComponent<RCC_CarControllerV3>().canControl = true;
        }

    }
}
