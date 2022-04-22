using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum KeyboardKey { None, W, A, S, D};

public class HoldScript : MonoBehaviour
{
    [SerializeField]
    public KeyboardKey currentKey;
    private TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        int num = Random.Range(1, 5);
        if (num == 1)
        {
            currentKey = KeyboardKey.W;
        }
        else if (num == 2)
        {
            currentKey = KeyboardKey.A;
        }
        else if (num == 3)
        {
            currentKey = KeyboardKey.S;
        }
        else if (num == 4)
        {
            currentKey = KeyboardKey.D;
        }

        switch (currentKey)
        {
            case KeyboardKey.W:
                text.text = "W";
                break;
            case KeyboardKey.A:
                text.text = "A";
                break;
            case KeyboardKey.S:
                text.text = "S";
                break;
            case KeyboardKey.D:
                text.text = "D";
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
