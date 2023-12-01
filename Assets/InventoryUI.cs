using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI pointText;
    void Start()
    {
        pointText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdatePointText(PlayerInventory playerInventory)
    {
        pointText.text = playerInventory.NumberOfPoints.ToString();
    }
}

