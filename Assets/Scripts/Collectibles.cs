using UnityEngine;

public class Collectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) // Change to 3D if you're working in 3D
    {
        // Check if the object that collided with the collectible is the player
        if (other.CompareTag("Player"))
        {
            // Increase the player's collectible count (handled in another script)
            FindObjectOfType<GameManager>().AddCollectible();

            // Destroy the collectible after it has been collected
            Destroy(gameObject);
        }
    }
}
