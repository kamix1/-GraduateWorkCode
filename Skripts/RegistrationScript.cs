using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class RegistrationScript : MonoBehaviour
{
    public TMP_InputField UsernameInput;
    public TMP_InputField PasswordInput;

    public Button SubmitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", UsernameInput.text);
        form.AddField("password", PasswordInput.text);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/ew.php", form))
        {
            yield return www.SendWebRequest();
            if (www.downloadHandler.text == "0")
            {
                Debug.Log("User created sucessfully");
                UnityEngine.SceneManagement.SceneManager.LoadScene("RegisterScene");
            }
            else
            {
                Debug.Log("User creation failed. Error #" + www.downloadHandler.text);
            }
        }
    }

    public void VerifyInputs()
    {
        SubmitButton.interactable = (UsernameInput.text.Length >= 8 && PasswordInput.text.Length >= 8);
    }
}
