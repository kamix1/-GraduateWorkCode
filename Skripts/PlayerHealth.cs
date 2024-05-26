using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerHealth : MonoBehaviour
{
    public static int playerHealth;
    public static int playerMaxHealth;
    public static bool gameOver;
    public TextMeshProUGUI text;
    public TextMeshProUGUI MaxHealth;
    public TextMeshProUGUI Moneytext;
    public GameObject RedOverlay;
    public GameObject Character;
    public GameObject VictoryScreen;
    public Slider slider;
    public static int EnemyKilled;
    public float starttime;
    public int x;

    private void Awake()
    {
        
    }
    void Start()
    {
        x = DBmanager.x;
        Debug.Log(x);
        Character.transform.position = new Vector3(DBmanager.x, DBmanager.y, DBmanager.z);
        playerMaxHealth = 100;
        playerHealth = playerMaxHealth;
        gameOver = false;
        EnemyKilled = 0;
      
    }

    // Update is called once per frame
    void Update()
    {
        
        text.text = "" + playerHealth;
        MaxHealth.text = "" + playerMaxHealth;
        Moneytext.text = "" + Character.GetComponent<PlayerMoneyScript>().money;
        slider.maxValue = playerMaxHealth;
        slider.value = playerHealth;
        if (gameOver == true)
        {
            DBmanager.x = 0;
            DBmanager.y = 2;
            DBmanager.z = 0;
            SceneManager.LoadScene("SampleScene");
        }
        if (EnemyKilled >= 10)
        {
            Time.timeScale = 0f;
            VictoryScreen.SetActive(true);
        }
        starttime -= Time.deltaTime;
        if (starttime < 1 && RedOverlay.activeInHierarchy)
        {
            RedOverlay.SetActive(false);
            starttime = 10;
        }
        DBmanager.score = int.Parse(Moneytext.text);
    }

    public void Savepos()
    {
        DBmanager.x = (int)Character.transform.position.x;
        DBmanager.y = (int)Character.transform.position.y + 2;
        DBmanager.z = (int)Character.transform.position.z;
    }
    public IEnumerator Damage(int damageAmmount)
    {
            playerHealth -= damageAmmount;
            RedOverlay.SetActive(true);
            starttime = 10;
            if (playerHealth <= 0)
                gameOver = true;
            yield return new WaitForSeconds(0.5f);
            RedOverlay.SetActive(false);
    }

    public void callSaveData()
    {
        StartCoroutine(SavePlayerData());
    }
    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBmanager.username);
        form.AddField("score", DBmanager.score);
        form.AddField("X", DBmanager.x);
        form.AddField("Y", DBmanager.y);
        form.AddField("Z", DBmanager.z);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/savedata.php", form);
        yield return www;
        if (www.downloadHandler.text == "0")
        {
            Debug.Log("GameSaved");
        }
        else
        {
            Debug.Log("Can`t save the game");
        }

        DBmanager.LogOut();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
