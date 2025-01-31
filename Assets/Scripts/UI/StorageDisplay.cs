using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

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
        StringBuilder sb = new StringBuilder("Inventory:\n");
        for (int i = 0; i < (int)ResourceType.MAX_VALUE; i++)
        {
            if (storage.resources[i] > 0)
            {
                sb.Append((ResourceType)i);
                sb.Append(": ");
                sb.Append(storage.resources[i]);
                sb.Append('\n');
            }
        }

        // Update the Text component with the resources
        storageText.text = sb.ToString();
    }
}
