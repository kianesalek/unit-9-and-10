using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dIAMOND : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.DiamondsCollected();
            gameObject.SetActive(false);
        }
    }
}
