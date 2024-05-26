using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class LogIn : MonoBehaviour
{
    public TMP_InputField UsernameInput;
    public TMP_InputField PasswordInput;

    public Button SubmitButton;

    public void CallLogIn()
    {
        StartCoroutine(LogInUser());
    }

    IEnumerator LogInUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", UsernameInput.text);
        form.AddField("password", PasswordInput.text);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/login.php", form))
        {
            yield return www.SendWebRequest();
            if (www.downloadHandler.text.StartsWith("0"))
            {
                DBmanager.username = UsernameInput.text;
                DBmanager.score = int.Parse(www.downloadHandler.text.Split('\t')[1]);
                DBmanager.x = int.Parse(www.downloadHandler.text.Split('\t')[2]);
                DBmanager.y = int.Parse(www.downloadHandler.text.Split('\t')[3]);
                DBmanager.z = int.Parse(www.downloadHandler.text.Split('\t')[4]);
                UnityEngine.SceneManagement.SceneManager.LoadScene("RegisterScene");
            }
            else
            {
                Debug.Log("User LogIn failed. Error# " + www.downloadHandler.text);
            }
        }
    }

    public void VerifyInputs()
    {
        SubmitButton.interactable = (UsernameInput.text.Length >= 8 && PasswordInput.text.Length >= 8);
    }
}
