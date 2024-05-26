using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RegistrationFormScript : MonoBehaviour
{
    public Text text;
    public Button register;
    public Button login;
    public Button toGame;
    private void Start()
    {
        if (DBmanager.LoggedIn)
        {
            text.text = "User: " + DBmanager.username;
        }
        register.interactable = !DBmanager.LoggedIn;
        login.interactable = !DBmanager.LoggedIn;
        toGame.interactable = DBmanager.LoggedIn;
    }
    public void goToForm()
    {
        SceneManager.LoadScene("RegisterForm");
    }
    public void goToLogIn()
    {
        SceneManager.LoadScene("LogInForm");
    }
    public void goToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
