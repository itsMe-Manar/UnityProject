using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    // Reference to the pop-up panel
    public GameObject popUpPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show the pop-up panel
            popUpPanel.SetActive(true);

            // Optionally, you can load the next scene here or handle other game logic
            // Example: Load next scene after a delay
            Invoke("LoadNextScene", 2f); // Load next scene after 2 seconds (adjust delay as needed)
        }
    }

    void LoadNextScene()
    {
        // Load the next scene
        // Example:
         SceneManager.LoadScene("Klausurphase");
        // Replace "NextSceneName" with your actual scene name
    }
}
