using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartCoundown : MonoBehaviour
{
    public Text countDownDisplay;

    void Start()
    {
        StartCoroutine(CountDown());
    }

    
    IEnumerator CountDown()
    {
        countDownDisplay.text = "3";
        yield return new WaitForSeconds(1f);
        countDownDisplay.text = "2";
        yield return new WaitForSeconds(1f);
        countDownDisplay.text = "1";
        yield return new WaitForSeconds(1f);
        countDownDisplay.text = "GO!";
        yield return new WaitForSeconds(0.5f);
        countDownDisplay.enabled = false;
        LapTimeCounter.isCountingTime = true;
        TotalTimeCounter.isCountingTime = true;

    }
}
