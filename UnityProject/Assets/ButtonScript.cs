using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public string levelToLoad; // The name of the level to load when this button is clicked
    public bool isExitButton; // To differentiate if this is the exit button

    void OnMouseDown()
    {
        if (isExitButton)
        {
            SceneController.LoadMainMenu();
        }
        else
        {
            SceneController.LoadScene(levelToLoad);
        }
    }
}
