using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;

    public static LevelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("LevelManager").AddComponent<LevelManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void MarkLevelAsCompleted(int levelIndex)
    {
        PlayerPrefs.SetInt("Level_" + levelIndex, 1);
        PlayerPrefs.Save();
    }

    public bool IsLevelCompleted(int levelIndex)
    {
        return PlayerPrefs.GetInt("Level_" + levelIndex, 0) == 1;
    }

    public bool IsLevelUnlocked(int levelIndex)
    {
        if (levelIndex == 1)
        {
            return true; // First level is always unlocked
        }
        return IsLevelCompleted(levelIndex - 1);
    }
}
