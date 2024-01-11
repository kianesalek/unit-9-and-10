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
            other.transform.position = new Vector3(destination.transform.position.x, other.transform.position.y, destination.transform.position.z);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        active = true;
    }
}
