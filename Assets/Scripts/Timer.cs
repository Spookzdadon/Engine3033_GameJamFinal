using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeValue = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= 0.8f * Time.deltaTime;

        }
        else
        {
            timerText.text = "";
            timeValue = 0;
        }
        float seconds = Mathf.FloorToInt(timeValue % 60);
        //timerText.text = seconds.ToString();
        timerText.text = timeValue.ToString("F2");
    }
}
