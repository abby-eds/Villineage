using UnityEngine;
using TMPro;

public class InventoryDisplay : MonoBehaviour
{
    // Reference to the Villager script
    public Villager villager;

    // Reference to the TextMeshPro component
    public TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Update()
    {
        // Check if the Villager script is assigned
        if (villager == null)
        {
            Debug.LogWarning("Villager reference is not assigned.");
            return;
        }

        // Check if the TextMeshPro component is assigned
        if (textMesh == null)
        {
            Debug.LogWarning("TextMeshPro reference is not assigned.");
            return;
        }

        // Display the resources of the villager
        string resourcesText = "Resources:\n";
        foreach (var resource in villager.resources)
        {
            resourcesText += resource.Key.ToString() + ": " + resource.Value + "\n";
        }
        textMesh.text = resourcesText;
    }
}
