using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void EnterTheGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitTheGame()
    {
        SceneManager.LoadScene("RegisterScene");
        Application.Quit();
    }

    
}
