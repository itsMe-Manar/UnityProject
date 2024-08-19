using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject playButton;
    public GameObject settingsButton;
    public GameObject newButton;
    public GameObject creditsButton;

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
                }else if (hit.collider.gameObject == creditsButton)
                {
                    OnCreditsButtonClicked();
                }
            }
        }
    }

    void OnPlayButtonClicked()
    {
        // Load the map scene
        SplashScreenManager.LoadSceneWithSplash("Map");
    }
    void OnNewButtonClicked()
    {
        // Reset the game state
        ResetGame();
        // Load the map scene
        SplashScreenManager.LoadSceneWithSplash("newGameMenu");
    }

    void OnSettingsButtonClicked()
    {
        SplashScreenManager.LoadSceneWithSplash("mapMenuSettings");
    }
    void OnCreditsButtonClicked()
    {
        SplashScreenManager.LoadSceneWithSplash("creditScreen");
    }

    void ResetGame()
    {
        // Implement your game reset logic here
        PlayerPrefs.DeleteAll(); // Example: Reset all PlayerPrefs
        // Add any additional reset logic you need
    }
}
