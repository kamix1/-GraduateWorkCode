using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 InputVector { get; private set; }
    public Vector3 MousePosition { get; private set; }

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("IsWalking", true);
        }
        else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("IsWalking", false);
        }
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        InputVector = new Vector2(h, v);
        MousePosition = Input.mousePosition;
    }
}
