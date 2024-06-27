using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

   /* public static void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

   
}
