using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    void Update()
    {
        // Check if the pause panel is active and if any mouse button is clicked
        if (PausePanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            Continue();
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
