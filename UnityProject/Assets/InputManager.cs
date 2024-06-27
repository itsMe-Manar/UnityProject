using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the click is over a UI element
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                // Handle game world click (not over UI)
                HandleGameWorldClick();
            }
        }
    }

    void HandleGameWorldClick()
    {
        Debug.Log("Clicked on game world.");
        // Implement your game logic here
    }
}
