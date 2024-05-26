using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    Animator animator;
    public GameObject Weapon;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(Time.timeScale != 0)
                AudioManager.instance.Play("Hit");
            animator.SetBool("IsAttacking", true);
            Weapon.GetComponent<MeshCollider>().isTrigger = true;

        }
        else if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("IsAttacking", false);
            Weapon.GetComponent<MeshCollider>().isTrigger = false;
        }
    }
}
