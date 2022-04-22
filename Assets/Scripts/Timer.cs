using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI startTimerText;
    public float timeValue = 10;
    public float startTimerValue = 4;
    public bool startTimerDone = false;
    PlayerController[] playerControllers;
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        playerControllers = FindObjectsOfType<PlayerController>();
        timerText.text = "";
        foreach (PlayerController player in playerControllers)
        {
            player.finishedGame = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!startTimerDone)
        {
            if (startTimerValue > 0)
            {
                startTimerValue -= Time.deltaTime;
                startTimerText.text = startTimerValue.ToString("F0");
            }
            else
            {
                startTimerValue = 0;
                startTimerText.text = "";
                foreach (PlayerController player in playerControllers)
                {
                    player.finishedGame = false;
                }
                startTimerDone = true;
                music.Play();
            }
        }
        else
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
            timerText.text = timeValue.ToString("F1");
        }
        
    }
}
