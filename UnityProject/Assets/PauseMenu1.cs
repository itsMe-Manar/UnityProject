using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Add this namespace for UI elements

public class PauseMenu1 : MonoBehaviour
{
    public GameObject PauseMenuPanel;
    public GameObject QuitConfirmationPanel; // Reference to the confirmation dialog panel

    void Start()
    {
        if (PauseMenuPanel == null)
        {
            Debug.LogError("PauseMenuPanel is not assigned in the Inspector.");
        }
        else
        {
            PauseMenuPanel.SetActive(false); // Ensure it's hidden at the start
        }

        if (QuitConfirmationPanel == null)
        {
            Debug.LogError("QuitConfirmationPanel is not assigned in the Inspector.");
        }
        else
        {
            QuitConfirmationPanel.SetActive(false); // Ensure it's hidden at the start
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        if (PauseMenuPanel != null)
        {
            Debug.Log("PauseGame called.");
            PauseMenuPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("PauseMenuPanel is not assigned.");
        }
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        if (PauseMenuPanel != null)
        {
            Debug.Log("ResumeGame called.");
            PauseMenuPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("PauseMenuPanel is not assigned.");
        }
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Debug.Log("RestartGame called.");
        Time.timeScale = 1f; // Ensure time scale is reset to normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void QuitGame()
    {
        if (QuitConfirmationPanel != null)
        {
            Debug.Log("QuitGame called.");
            QuitConfirmationPanel.SetActive(true); // Show the confirmation dialog
        }
        else
        {
            Debug.LogError("QuitConfirmationPanel is not assigned.");
        }
    }

    public void ConfirmQuit()
    {
        Debug.Log("ConfirmQuit called.");
        Application.Quit(); // Quit the application
    }

    public void CancelQuit()
    {
        if (QuitConfirmationPanel != null)
        {
            Debug.Log("CancelQuit called.");
            QuitConfirmationPanel.SetActive(false); // Hide the confirmation dialog
        }
        else
        {
            Debug.LogError("QuitConfirmationPanel is not assigned.");
        }
    }
}
