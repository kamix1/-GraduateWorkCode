using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    public int damageAmmount = 10;
    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject)
        StartCoroutine(FindObjectOfType<PlayerHealth>().Damage(damageAmmount));
    }
}
