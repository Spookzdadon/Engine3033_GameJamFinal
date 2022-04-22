using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum KeyboardKey { None, W, A, S, D, I, J, K, L, UpArrow, LeftArrow, DownArrow, RightArrow};
public enum playerNum { Player1, Player2, Player3 };

public class HoldScript : MonoBehaviour
{
    [SerializeField]
    public KeyboardKey currentKey;
    [SerializeField]
    public playerNum playerNumber;
    public GameObject circle;
    public bool isNext = false;
    private TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        circle.SetActive(false);
        text = GetComponentInChildren<TextMeshProUGUI>();
        int num = Random.Range(1, 5);
        if (num == 1)
        {
            if (playerNumber == playerNum.Player1)
            {
                currentKey = KeyboardKey.W;
            }
            else if (playerNumber == playerNum.Player2)
            {
                currentKey = KeyboardKey.I;
            }
            else if (playerNumber == playerNum.Player3)
            {
                currentKey = KeyboardKey.UpArrow;
            }
        }
        else if (num == 2)
        {
            if (playerNumber == playerNum.Player1)
            {
                currentKey = KeyboardKey.A;
            }
            else if (playerNumber == playerNum.Player2)
            {
                currentKey = KeyboardKey.J;
            }
            else if (playerNumber == playerNum.Player3)
            {
                currentKey = KeyboardKey.LeftArrow;
            }
        }
        else if (num == 3)
        {
            if (playerNumber == playerNum.Player1)
            {
                currentKey = KeyboardKey.S;
            }
            else if (playerNumber == playerNum.Player2)
            {
                currentKey = KeyboardKey.K;
            }
            else if (playerNumber == playerNum.Player3)
            {
                currentKey = KeyboardKey.DownArrow;
            }
        }
        else if (num == 4)
        {
            if (playerNumber == playerNum.Player1)
            {
                currentKey = KeyboardKey.D;
            }
            else if (playerNumber == playerNum.Player2)
            {
                currentKey = KeyboardKey.L;
            }
            else if (playerNumber == playerNum.Player3)
            {
                currentKey = KeyboardKey.RightArrow;
            }
        }

        text.text = currentKey.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (isNext)
        {
            circle.SetActive(true);
        }
        else
        {
            circle.SetActive(false);
        }
    }
}
