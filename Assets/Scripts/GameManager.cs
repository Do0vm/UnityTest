using UnityEngine;
using TMPro; // Required for TextMeshPro

public class GameManager : MonoBehaviour
{
    // Reference to the TMP Text component
    public TMP_Text collectibleText;

    // Variable to store the count of collectibles
    private int collectibleCount = 0;

    // Method to add to the collectible count
    public void AddCollectible()
    {
        // Increase the collectible count
        collectibleCount++;

        // Update the TextMeshPro UI text to reflect the new collectible count
        collectibleText.text = "x " + collectibleCount;
    }
}
