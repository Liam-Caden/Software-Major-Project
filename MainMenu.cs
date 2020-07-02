using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Instructions;
 
    //maps different buttons to objects and scenes
    public void StartGame()
    {
        SceneManager.LoadScene("Beginning");
    }

    public void InstructionsBtn()
    {
        Instructions.SetActive(true);
    }

    public void Back()
    {
        Instructions.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
