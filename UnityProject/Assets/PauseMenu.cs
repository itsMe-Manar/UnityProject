using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel; // The pause menu panel
    public Button pauseButton; // The pause button
    public Button resumeButton; // The resume button
    public Button backToMenuButton; // The back to menu button

    private bool isPaused = false;

    void Start()
    {
        // Ensure the pause menu is initially hidden
        pauseMenuPanel.SetActive(false);

        // Add listeners to the buttons
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
        backToMenuButton.onClick.AddListener(BackToMenu);
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pause the game
        pauseMenuPanel.SetActive(true); // Show the pause menu
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume the game
        pauseMenuPanel.SetActive(false); // Hide the pause menu
    }

    void BackToMenu()
    {
        Time.timeScale = 1f; // Ensure the game is not paused when returning to the menu
        SceneManager.LoadScene("Menu"); // Replace with your main menu scene name
    }

    void Update()
    {
        // Optional: You can add a key press check to pause/resume the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
