using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal destination;
    [HideInInspector]
    public bool active = true;
    private void OnTriggerEnter(Collider other)
    {
        if (!active) return;
        if (other.CompareTag("Player"))
        {
            destination.active = false;
            other.transform.position = destination.transform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        active = true;
    }
}
