using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public playerNum numPlayer;
    public int playerNumInt;
    public int index = 0;
    public KeyboardKey nextKey;
    public KeyboardKey currentPressedKey;
    public GameObject[] keys;
    public Transform nextKeyPos;
    public bool isDoneClimbingUp = true;
    public bool isDoneClimbingDown = true;
    public float speed;
    public bool finishedGame = false;
    public Transform startPos;
    private Animator animator;
    private bool keyPressed = false;
    public GameObject finishText;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        startPos.position = new Vector3(startPos.position.x, startPos.position.y + 1.7f, startPos.position.z);
        if (numPlayer == playerNum.Player1)
        {
            keys = GameObject.FindGameObjectsWithTag("Hold");
            playerNumInt = 1;
        }
        else if (numPlayer == playerNum.Player2)
        {
            keys = GameObject.FindGameObjectsWithTag("Hold2");
            playerNumInt = 2;
        }
        else if (numPlayer == playerNum.Player3)
        {
            keys = GameObject.FindGameObjectsWithTag("Hold3");
            playerNumInt = 3;
        }
        //System.Array.Reverse(keys);
        nextKey = keys[index].GetComponent<HoldScript>().currentKey;
        nextKeyPos = keys[index].transform;
        keys[index].GetComponent<HoldScript>().isNext = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDoneClimbingUp)
        {
            Vector3 tempLocation = new Vector3(transform.position.x, nextKeyPos.position.y - 1.2f, nextKeyPos.position.z);
            transform.position = Vector3.MoveTowards(transform.position, tempLocation, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, tempLocation) < 0.001f)
            {
                isDoneClimbingUp = true;
                if (index < keys.Length)
                {
                    nextKeyPos = keys[index].transform;
                    nextKey = keys[index].GetComponent<HoldScript>().currentKey;
                    keys[index].GetComponent<HoldScript>().isNext = true;
                }
                else
                {
                    FinishGame();
                    gameManager.playersFinished.Add(playerNumInt);
                }
            }
        }

        if (!isDoneClimbingDown)
        {
            Transform tempTransform;

            if (index == 0)
            {
                tempTransform = startPos;
            }
            else
            {
                tempTransform = keys[index - 1].transform;
            }
            Vector3 tempLocation = new Vector3(transform.position.x, tempTransform.position.y - 1.2f, tempTransform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, tempLocation, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, tempLocation) < 0.001f)
            {
                isDoneClimbingDown = true;
                nextKeyPos = keys[index].transform;
                nextKey = keys[index].GetComponent<HoldScript>().currentKey;
                keys[index].GetComponent<HoldScript>().isNext = true;
            }
        }
        if (numPlayer == playerNum.Player1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                currentPressedKey = KeyboardKey.W;
                keyPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                currentPressedKey = KeyboardKey.A;
                keyPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                currentPressedKey = KeyboardKey.S;
                keyPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                currentPressedKey = KeyboardKey.D;
                keyPressed = true;
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                currentPressedKey = KeyboardKey.None;
                keyPressed = false;
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                currentPressedKey = KeyboardKey.None;
                keyPressed = false;
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                currentPressedKey = KeyboardKey.None;
                keyPressed = false;
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                currentPressedKey = KeyboardKey.None;
                keyPressed = false;
            }
        }

        else if (numPlayer == playerNum.Player2)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                currentPressedKey = KeyboardKey.I;
                keyPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                currentPressedKey = KeyboardKey.J;
                keyPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                currentPressedKey = KeyboardKey.K;
                keyPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                currentPressedKey = KeyboardKey.L;
                keyPressed = true;
            }

            if (Input.GetKeyUp(KeyCode.I))
            {
                currentPressedKey = KeyboardKey.None;
                keyPressed = false;
            }
            else if (Input.GetKeyUp(KeyCode.J))
            {
                currentPressedKey = KeyboardKey.None;
                keyPressed = false;
            }
            else if (Input.GetKeyUp(KeyCode.K))
            {
                currentPressedKey = KeyboardKey.None;
                keyPressed = false;
            }
            else if (Input.GetKeyUp(KeyCode.L))
            {
                currentPressedKey = KeyboardKey.None;
                keyPressed = false;
            }
        }

        else if (numPlayer == playerNum.Player3)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentPressedKey = KeyboardKey.UpArrow;
                keyPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentPressedKey = KeyboardKey.LeftArrow;
                keyPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentPressedKey = KeyboardKey.DownArrow;
                keyPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentPressedKey = KeyboardKey.RightArrow;
                keyPressed = true;
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                currentPressedKey = KeyboardKey.None;
                keyPressed = false;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                currentPressedKey = KeyboardKey.None;
                keyPressed = false;
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                currentPressedKey = KeyboardKey.None;
                keyPressed = false;
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                currentPressedKey = KeyboardKey.None;
                keyPressed = false;
            }
        }

        if (keyPressed)
        {
            if (currentPressedKey == nextKey && isDoneClimbingUp && isDoneClimbingDown && index < keys.Length)
            {
                isDoneClimbingUp = false;
                keys[index].GetComponent<HoldScript>().isNext = false;
                if (index % 2 == 0)
                {
                    animator.SetTrigger("ClimbLeft");
                }
                else
                {
                    animator.SetTrigger("ClimbRight");
                }
                index++;
            }
            else if (currentPressedKey != nextKey && isDoneClimbingUp && isDoneClimbingDown && index < keys.Length)
            {
                isDoneClimbingDown = false;
                keys[index].GetComponent<HoldScript>().isNext = false;
                if (index <= 2)
                {
                    index = 0;
                }
                else
                {
                    index -= 2;
                }
                nextKey = keys[index].GetComponent<HoldScript>().currentKey;
                nextKeyPos = keys[index].transform;
                animator.SetTrigger("Idle");
            }
        }
    }

    public void FinishGame()
    {
        finishedGame = true;
        finishText.SetActive(true);
    }
}
