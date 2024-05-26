using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shopMenu;
    public GameObject Character;
    public GameObject shopModel;
    public GameObject shopButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Character.transform.position,shopModel.transform.position) < 2)
        {
            shopButton.SetActive(true);
        }
        else if(Vector3.Distance(Character.transform.position, shopModel.transform.position) >= 2)
        {
            shopButton.SetActive(false);
        }
    }

    public void collapseShop()
    {
        Time.timeScale = 1f;
        shopMenu.SetActive(false);
    }

    public void OpenShop()
    {
        Time.timeScale = 0f;
        shopMenu.SetActive(true);
    }

    public void PurchaseHeal()
    {
        if (Character.GetComponent<PlayerMoneyScript>().money >= 10)
        {
            if (PlayerHealth.playerHealth != PlayerHealth.playerMaxHealth)
            {

                if (PlayerHealth.playerHealth <= PlayerHealth.playerMaxHealth - 10)
                    PlayerHealth.playerHealth += 10;
                else
                    PlayerHealth.playerHealth = PlayerHealth.playerMaxHealth;
                Character.GetComponent<PlayerMoneyScript>().money -= 10;
                DBmanager.score -= 10;
            }
            
            
        }
        else
        {

        }
    }
    
    public void PurchaseMaxHealth()
    {
        if (Character.GetComponent<PlayerMoneyScript>().money >= 15)
        {
            PlayerHealth.playerMaxHealth += 10;
            PlayerHealth.playerHealth += 10;
            Character.GetComponent<PlayerMoneyScript>().money -= 15;
            DBmanager.score -= 15;
        }
    }

    public void IncreseDamage()
    {
        if (Character.GetComponent<PlayerMoneyScript>().money >= 10)
        {
            WeaponDamage.DamageAmmount += 10;
            Character.GetComponent<PlayerMoneyScript>().money -= 10;
            DBmanager.score -= 10;
        }
    }
}
