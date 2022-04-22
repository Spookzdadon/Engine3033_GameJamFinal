using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScene : MonoBehaviour
{
    public List<int> playerWinOrder;
    public GameObject firstPlacePlayer;
    public GameObject secondPlacePlayer;
    public GameObject thirdPlacePlayer;
    public Transform firstPlaceLocation;
    public Transform secondPlaceLocation;
    public Transform thirdPlaceLocation;
    // Start is called before the first frame update
    void Start()
    {
        playerWinOrder = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().playersFinished;
        //playerWinOrder = new List<int> { 1, 2 };
        for (int i = 0; i < playerWinOrder.Count; i++)
        {
            if (i == 0)
            {
                firstPlacePlayer = GameObject.FindGameObjectWithTag("Player" + playerWinOrder[i]);
                firstPlacePlayer.GetComponent<Animator>().SetTrigger("FirstPlace");
                firstPlacePlayer.transform.position = firstPlaceLocation.position;
                firstPlacePlayer.transform.rotation = firstPlaceLocation.rotation;
            }

            else if (i == 1)
            {
                secondPlacePlayer = GameObject.FindGameObjectWithTag("Player" + playerWinOrder[i]);
                secondPlacePlayer.GetComponent<Animator>().SetTrigger("SecondPlace");
                secondPlacePlayer.transform.position = secondPlaceLocation.position;
                secondPlacePlayer.transform.rotation = secondPlaceLocation.rotation;
            }

            else if (i == 2)
            {
                thirdPlacePlayer = GameObject.FindGameObjectWithTag("Player" + playerWinOrder[i]);
                thirdPlacePlayer.GetComponent<Animator>().SetTrigger("ThirdPlace");
                thirdPlacePlayer.transform.position = thirdPlaceLocation.position;
                thirdPlacePlayer.transform.rotation = thirdPlaceLocation.rotation;
            }
        }

        

        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
