using UnityEngine;
using UnityEngine.UI; // Required for UI elements
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Reference to the Play and Quit buttons
    public Button playButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure buttons are linked and call respective methods when clicked
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    // Method to load the game scene
    public void PlayGame()
    {
        // Replace "GameScene" with the actual name of your game scene
        SceneManager.LoadScene("SampleScene");
    }

    // Method to quit the application
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game!"); // This will log in the editor
    }
}
