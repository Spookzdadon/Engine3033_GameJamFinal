using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> playerList;
    public List<int> playersFinished;
    public List<int> playerIndex;
    public Timer timer;
    public bool isGameActive = true;
    public int smallestNum = 0;
    public AudioSource gameAudioSource;
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        playersFinished.Clear();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        PlayerController[] playerArray = FindObjectsOfType<PlayerController>();
        foreach (PlayerController player in playerArray)
        {
            playerList.Add(player.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            if (playersFinished.Count >= playerList.Count)
            {
                isGameActive = false;
                StartCoroutine(FinishGame());
            }

            if (timer.timeValue == 0)
            {
                isGameActive = false;
                foreach (GameObject player in playerList)
                {
                    player.GetComponent<PlayerController>().FinishGame();
                    playerIndex.Add(player.GetComponent<PlayerController>().index);
                    playerIndex.Sort();
                    playerIndex.Reverse();
                }


                for (int i = 0; i < playerIndex.Count; i++)
                {
                    foreach (GameObject player in playerList)
                    {
                        if (player.GetComponent<PlayerController>().index == playerIndex[i])
                        {
                            playersFinished.Add(player.GetComponent<PlayerController>().playerNumInt);
                        }
                    }
                }

                StartCoroutine(FinishGame());
            }
        }
    }

    IEnumerator FinishGame()
    {
        music.Stop();
        gameAudioSource.Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("2PlayerEndScene");
    }
}
