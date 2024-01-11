using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position; 
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy")) 
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = initialPosition; 
    }
}
