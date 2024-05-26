using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [System.NonSerialized]
    public static int DamageAmmount = 30;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        other.GetComponent<EnemyHealth>().TakingDamage(DamageAmmount);
    }
}
