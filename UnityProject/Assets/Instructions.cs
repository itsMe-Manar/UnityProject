using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject exitButton;
   // Reference to the instruction button

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
            SplashScreenManager.LoadSceneWithSplash("Map");
        }

      
    }
}
