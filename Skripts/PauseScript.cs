using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public bool IsPaused;
    public GameObject PauseGamemenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseGamemenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void Pause()
    {
        PauseGamemenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void save()
    {
        
        StartCoroutine(SavePlayerData());
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;     
        SceneManager.LoadScene("Menu");
    }
    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBmanager.username);
        form.AddField("score", DBmanager.score);
        form.AddField("X", DBmanager.x);
        form.AddField("Y", DBmanager.y);
        form.AddField("Z", DBmanager.z);
        using (WWW www = new WWW("http://localhost/sqlconnect/savedata.php", form))
        {
            yield return www;

            if (www.error != null)
            {
                Debug.Log("Error while saving game: " + www.error);
            }
            else
            {
                if (www.text == "0")
                {
                    Debug.Log("Game saved successfully");
                }
                else
                {
                    Debug.Log("Failed to save the game: " + www.text);
                }
            }
        }

        DBmanager.LogOut();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

}
