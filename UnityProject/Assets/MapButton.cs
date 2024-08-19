using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour
{
    public int levelIndex;
    public Color completedColor = Color.blue;
    public Color defaultColor = Color.magenta;
    public string levelSceneName;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateButtonColor();
    }

    public void UpdateButtonColor()
    {
        if (LevelManager.Instance.IsLevelCompleted(levelIndex))
        {
            spriteRenderer.color = completedColor;
        }
        else
        {
            spriteRenderer.color = defaultColor;
        }
    }
    void OnMouseDown()
    {
        // Check if the level is unlocked before loading it
        if (LevelManager.Instance.IsLevelUnlocked(levelIndex))
        {
            SplashScreenManager.LoadSceneWithSplash(levelSceneName);
        }
        else
        {
            Debug.Log("Level " + levelIndex + " is locked and cannot be accessed.");
            // Optionally, you can show a message to the player indicating the level is locked
        }
    }

}
