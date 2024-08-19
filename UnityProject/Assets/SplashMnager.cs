using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashScreenManager : MonoBehaviour
{
    public float splashDuration = 3f; // Duration for which the splash screen will be shown

    void Start()
    {
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(splashDuration);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(PlayerPrefs.GetString("NextScene"));

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public static void LoadSceneWithSplash(string nextSceneName)
    {
        PlayerPrefs.SetString("NextScene", nextSceneName);
        SceneManager.LoadScene("splash");
    }
}
