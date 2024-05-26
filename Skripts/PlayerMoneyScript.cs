using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMoneyScript : MonoBehaviour
{
    public int money;
    public string score;
    void Start()
    {
        money = DBmanager.score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AudioManager.instance.Play("TakeMoney");
            money += Random.Range(5, 10);
            DBmanager.score = money;
            Debug.Log(DBmanager.score);
            other.gameObject.SetActive(false);
        }
    }

    
}
