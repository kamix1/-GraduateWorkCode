using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private int HP = 100;
    public Slider healthbar;
    public GameObject coin;

    // Update is called once per frame
    void Update()
    {
        healthbar.value = HP;
    }

    public void TakingDamage(int DamageAmmount)
    {
        HP -= DamageAmmount;
        if(HP <= 0)
        {
            gameObject.SetActive(false);
            GetComponent<Collider>().enabled = false;
            healthbar.gameObject.SetActive(false);
        
            Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
            Instantiate(coin, pos, Quaternion.identity);
            PlayerHealth.EnemyKilled++;
        }
    }
}
