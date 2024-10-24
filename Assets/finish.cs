using UnityEngine;
using UnityEngine.SceneManagement; // Import for scene management

public class TriggerHandler : MonoBehaviour
{
    // This method is called when the object enters the trigger collider
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the collided object has the tag "Player"
        if (collider.CompareTag("Player")) // Use "Player" for the player object
        {
            // Call the function to handle the scene finish
            FinishScene();
        }
    }

    // Method to handle scene transition
    private void FinishScene()
    {
        // Load the scene named "GameOver" or replace with your desired scene
        SceneManager.LoadScene("Finish");
    }
}
