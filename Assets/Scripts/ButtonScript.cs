using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonScript : MonoBehaviour
{
    public GameObject currentCanvas;
    public GameObject nextCanvas;
    public void NextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void NextCanvas()
    {
        nextCanvas.SetActive(true);
        currentCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
