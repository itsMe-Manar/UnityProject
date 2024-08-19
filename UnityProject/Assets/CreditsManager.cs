using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CreditsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject exitButton;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == exitButton)
                {
                    OnPlayButtonClicked();
                }

            }
        }

        void OnPlayButtonClicked()
        {
            // Load the map scene
            SplashScreenManager.LoadSceneWithSplash("Menu");
        }
    }
}
