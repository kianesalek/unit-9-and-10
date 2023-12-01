using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfPoints { get; private set; }

    public UnityEvent<PlayerInventory> OnPointsCollected;

    public void DiamondsCollected()
    {
        NumberOfPoints++;
        OnPointsCollected.Invoke(this);    
    }
}
