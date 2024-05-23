using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StorageDisplay : MonoBehaviour
{
    public Storage storage;
    public TextMeshProUGUI storageText;

    void Update()
    {
        // Ensure a reference to the storage is set
        if (storage == null)
        {
            Debug.LogError("TownCenter reference not set in ResourceDisplay script!");
            return;
        }

        // Ensure a reference to the Text component is set
        if (storageText == null)
        {
            Debug.LogError("Text component reference not set in ResourceDisplay script!");
            return;
        }

        // Update the resource display
        UpdateResourceDisplay();
    }

    void UpdateResourceDisplay()
    {
        // Get the resources from the storage
        int wood = storage.resources[(int)ResourceType.Wood];
        int food = storage.resources[(int)ResourceType.Food];

        // Update the Text component with the resources
        storageText.text = "Wood: " + wood + "\n" + "Food: " + food;
    }
}