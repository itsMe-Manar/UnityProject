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
        // Load the level scene when the button is clicked
        SceneManager.LoadScene(levelSceneName);
    }
}
