using UnityEngine;
using UnityEngine.UI;

public class ExamManager : MonoBehaviour
{
    public Toggle[] answerToggles; // Array to hold the toggles
    public GameObject congratsPopup; // Reference to the "Congrats" popup GameObject
    public GameObject tryAgainPopup; // Reference to the "Try Again" popup GameObject
    public int correctAnswerIndex; // Index of the correct answer
    private AudioManager audioManager;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        // Ensure popups are inactive at the start
        congratsPopup.SetActive(false);
        tryAgainPopup.SetActive(false);

        // Initialize all toggles to be off and interactable
        foreach (Toggle toggle in answerToggles)
        {
            toggle.isOn = false; // Ensure the toggle is off
            toggle.interactable = true; // Ensure the toggle is interactable
        }

        // Add listeners to the toggles
        for (int i = 0; i < answerToggles.Length; i++)
        {
            int index = i; // Cache the index to avoid closure issues
            answerToggles[i].onValueChanged.AddListener(delegate { OnToggleValueChanged(index); });
        }
    }

    void OnToggleValueChanged(int index)
    {
        // Check if the toggle was turned on
        if (answerToggles[index].isOn)
        {
            // Check if the answer is correct
            if (index == correctAnswerIndex)
            {
                audioManager.PlaySFX(audioManager.popUpSoundHappy);
                congratsPopup.SetActive(true);
            }
            else
            {
                audioManager.PlaySFX(audioManager.popUpSoundsad);
                tryAgainPopup.SetActive(true);
            }

            // Disable all toggles to prevent multiple selections
            foreach (Toggle toggle in answerToggles)
            {
                toggle.interactable = false;
            }
        }
    }

    void Update()
    {
        // Check for user click to handle popup
        if (Input.GetMouseButtonDown(0))
        {
            if (congratsPopup.activeSelf)
            {
                // Handle correct answer: go back to the map
                SceneController.LoadScene("Map"); // Replace "Map" with the actual scene name
            }
            else if (tryAgainPopup.activeSelf)
            {
                // Handle incorrect answer: reload the current level
                SceneController.LoadScene("LucaNewScene"); // Replace "LucaNewScene" with the actual scene name
            }
        }
    }

    // Reset function to be called when retrying the exam
    public void ResetExam()
    {
        congratsPopup.SetActive(false);
        tryAgainPopup.SetActive(false);

        foreach (Toggle toggle in answerToggles)
        {
            toggle.isOn = false;
            toggle.interactable = true;
        }
    }
}
