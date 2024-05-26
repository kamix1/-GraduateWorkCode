using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarFollowing : MonoBehaviour
{
    public Transform Player;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(Player);
    }
}
