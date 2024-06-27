using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject playButton;
    public GameObject settingsButton;
    public GameObject newButton;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == playButton)
                {
                    OnPlayButtonClicked();
                }
                else if (hit.collider.gameObject == newButton)
                {
                    OnNewButtonClicked();
                }
                else if (hit.collider.gameObject == settingsButton)
                {
                    OnSettingsButtonClicked();
                }
            }
        }
    }

    void OnPlayButtonClicked()
    {
        // Load the map scene
        SceneManager.LoadScene("Map");
    }

    void OnNewButtonClicked()
    {
        // Reset the game state
        ResetGame();
        // Load the map scene
        SceneManager.LoadScene("Map");
    }

    void OnSettingsButtonClicked()
    {
        // Currently do nothing
    }

    void ResetGame()
    {
        // Implement your game reset logic here
        PlayerPrefs.DeleteAll(); // Example: Reset all PlayerPrefs
        // Add any additional reset logic you need
    }
}
