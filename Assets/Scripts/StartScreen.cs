using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void EndGame() 
    {
        Application.Quit();
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("JamesScene");
    }

    public void CreditScene() 
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void LoadStartScreen() 
    {
        SceneManager.LoadScene("StartScreen");
    }
}
