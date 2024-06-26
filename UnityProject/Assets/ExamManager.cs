using UnityEngine;
using UnityEngine.UI;

public class ExamManager : MonoBehaviour
{
    public Toggle[] answerToggles; // Array to hold the toggles
    public Text feedbackText; // Text to display feedback
    public int correctAnswerIndex; // Index of the correct answer

    void Start()
    {
        // Ensure the feedback text is empty at the start
        feedbackText.text = "";

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
                feedbackText.text = "Congrats, that's the right answer!";
            }
            else
            {
                feedbackText.text = "Oops, try again.";
            }

            // Disable all toggles to prevent multiple selections
            foreach (Toggle toggle in answerToggles)
            {
                toggle.interactable = false;
            }
        }
    }

    // Reset function to be called when retrying the exam
    public void ResetExam()
    {
        feedbackText.text = "";
        foreach (Toggle toggle in answerToggles)
        {
            toggle.isOn = false;
            toggle.interactable = true;
        }
    }
}
