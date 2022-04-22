using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int index = 0;
    public KeyboardKey nextKey;
    public KeyboardKey currentPressedKey;
    public GameObject[] keys;
    public Transform nextKeyPos;
    public bool isDoneClimbingUp = true;
    public bool isDoneClimbingDown = true;
    public float speed;
    public Transform startPos;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        startPos.position = new Vector3(startPos.position.x, startPos.position.y + 1.7f, startPos.position.z);
        keys = GameObject.FindGameObjectsWithTag("Hold");
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

        if (Input.GetKeyDown(KeyCode.W))
        {
            currentPressedKey = KeyboardKey.W;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            currentPressedKey = KeyboardKey.A;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            currentPressedKey = KeyboardKey.S;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            currentPressedKey = KeyboardKey.D;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            currentPressedKey = KeyboardKey.None;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            currentPressedKey = KeyboardKey.None;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            currentPressedKey = KeyboardKey.None;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            currentPressedKey = KeyboardKey.None;
        }

        if (Input.anyKeyDown)
        {
            if (currentPressedKey == nextKey && isDoneClimbingUp && isDoneClimbingDown && index < keys.Length)
            {
                isDoneClimbingUp = false;
                keys[index].GetComponent<HoldScript>().isNext = false;
                if (index%2==0)
                {
                        animator.SetTrigger("ClimbLeft");
                }
                else
                {
                    animator.SetTrigger("ClimbRight");
                }
                index++;
            }
            else if (currentPressedKey != nextKey && isDoneClimbingUp && isDoneClimbingDown)
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
}
