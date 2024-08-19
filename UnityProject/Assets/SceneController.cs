
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject[] levelLocks;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        UpdateLevelLocks();
    }

    public void UpdateLevelLocks()
    {
        for (int i = 0; i < levelLocks.Length; i++)
        {
            if (LevelManager.Instance.IsLevelUnlocked(i + 1))
            {
                levelLocks[i].SetActive(false); // Unlock the level
            }
            else
            {
                levelLocks[i].SetActive(true); // Keep the level locked
            }
        }
    }

    public void LoadLevel(int levelIndex)
    {
        if (LevelManager.Instance.IsLevelUnlocked(levelIndex))
        {
            SceneManager.LoadScene("Level_" + levelIndex);
        }
        else
        {
            Debug.Log("Level " + levelIndex + " is locked and cannot be accessed!");
            // Optionally, you can show a message to the player indicating the level is locked
        }
    }



    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public static void LoadScene(string sceneName)
    {
        // Assuming scene names follow a pattern like "Level_" + levelIndex
        int levelIndex;
        if (int.TryParse(sceneName.Replace("Level_", ""), out levelIndex))
        {
            if (LevelManager.Instance.IsLevelUnlocked(levelIndex))
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.Log("Attempted to access a locked level: " + sceneName);
                // Optionally, load a default scene or show an error message
                SceneManager.LoadScene("Map"); // Or any other fallback scene
            }
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioManager.instance.PlayBackgroundMusic(scene.name);
    }
}
