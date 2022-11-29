using UnityEngine;
using System.Collections;

public class DisplayCanvas : MonoBehaviour
{
    public GameObject canvas;

    void Start()
    {
        StartCoroutine(ShowCanvas());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.SetActive(true);
        }
    }

    
    IEnumerator ShowCanvas()
    {
        yield return new WaitForSeconds(13.6f);
        canvas.SetActive(true);
    }
}
