using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Instructions;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenInstructions()
    {
        Instructions.SetActive(true);
    }

    public void CloseInstructions()
    {
        Instructions.SetActive(false);
    }
}
