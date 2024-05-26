using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoving : MonoBehaviour
{

    private InputHandler _input;
    [SerializeField]
    public float MoveSpeed;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private bool isMouseControlled;
    Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        _input = GetComponent<InputHandler>();
        animator = GetComponent<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
        
        // move character forward
        var motionVector = MoveForward(targetVector);
        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("IsWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("IsWalking", false);
        }
        // rotate character to mouse position
        if (!isMouseControlled)
            RotateToMovementDir(motionVector);
        else
            RotateToMouse();
    }

    private void RotateToMouse()
    {
        Ray ray = _camera.ScreenPointToRay(_input.MousePosition);
        if(Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance:300f ))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }

    private void RotateToMovementDir(Vector3 motionVector)
    {
        if(motionVector.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(motionVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
    }

    private Vector3 MoveForward(Vector3 targetVector)
    {
        var speed = MoveSpeed * Time.deltaTime;
        targetVector = Quaternion.Euler(0, _camera.gameObject.transform.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }
}
