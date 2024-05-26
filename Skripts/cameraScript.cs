using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    [Header("Object for following")]
    [SerializeField]
    private GameObject character;
    [Header("Camera properties")]
    [SerializeField]
    private float _returnspeed;
    private float _height = 12f;
    private float _rearDistance = 3f;

    private Vector3 curentVector;
    void Start()
    {
        transform.position = new Vector3(character.transform.position.x, character.transform.position.y + _height, character.transform.position.z - _rearDistance);
        transform.rotation = Quaternion.LookRotation(character.transform.position - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
    }

    private void CameraMove()
    {
        curentVector = new Vector3(character.transform.position.x, character.transform.position.y + _height, character.transform.position.z - _rearDistance);
        transform.position = Vector3.Lerp(transform.position, curentVector, _returnspeed * Time.deltaTime);
    }
}
