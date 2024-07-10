using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButtonHandler : MonoBehaviour
{
    public enum ButtonType { Yes, No }
    public ButtonType buttonType;

    private void OnMouseDown()
    {
        switch (buttonType)
        {
            case ButtonType.Yes:
                ResetGame();
                break;
            case ButtonType.No:
                ReturnToMenu();
                break;
        }
    }

    private void ResetGame()
    {
        // Reset PlayerPrefs to clear saved data
        PlayerPrefs.DeleteAll();

        // Optionally, reset other game states here

        // Load the menu scene
        SceneManager.LoadScene("Menu");
    }

    private void ReturnToMenu()
    {
        // Just load the menu scene without resetting
        SceneManager.LoadScene("Menu");
    }
}
