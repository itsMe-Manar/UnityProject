

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExamManager : MonoBehaviour
{
    public Toggle[] answerToggles;
    public GameObject congratsPopup;
    public GameObject tryAgainPopup;
    public int correctAnswerIndex;
    public float examDuration = 60f; // Original duration
    public Text timerText;

    private float timer;
    private bool examFinished = false;
    private AudioManager audioManager;
    public string levelSceneName;
    public int levelIndex;

    void Start()
    {
        Debug.Log("ExamManager Start");

        // Ensure the game is not paused
        Time.timeScale = 1;

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        congratsPopup.SetActive(false);
        tryAgainPopup.SetActive(false);

        foreach (Toggle toggle in answerToggles)
        {
            toggle.isOn = false;
            toggle.interactable = true;
        }

        for (int i = 0; i < answerToggles.Length; i++)
        {
            int index = i;
            answerToggles[i].onValueChanged.AddListener(delegate { OnToggleValueChanged(index); });
        }

        // Initialize the timer
        timer = examDuration;
        Debug.Log("Timer Initialized: " + timer);

        UpdateTimerText();
    }

    void Update()
    {
        Debug.Log("Update called - Timer: " + timer + " examFinished: " + examFinished);

        if (!examFinished)
        {
            // Check Time.deltaTime value
            Debug.Log("Time.deltaTime: " + Time.deltaTime);
            Debug.Log("Time.timeScale: " + Time.timeScale);
            Debug.Log("Frame Count: " + Time.frameCount);

            // Decrease the timer
            timer -= Time.deltaTime;

            // Log after decrement
            Debug.Log("Timer after decrement: " + timer);

            if (timer <= 0)
            {
                timer = 0;
                OnExamTimeUp();
            }

            UpdateTimerText();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (congratsPopup.activeSelf)
            {
                SceneController.LoadScene("Map");
            }
            else if (tryAgainPopup.activeSelf)
            {
                SceneManager.LoadScene(levelSceneName);
            }
        }
    }

    void OnToggleValueChanged(int index)
    {
        if (answerToggles[index].isOn)
        {
            if (index == correctAnswerIndex)
            {
                audioManager.PlaySFX(audioManager.popUpSoundHappy);
                congratsPopup.SetActive(true);
                LevelManager.Instance.MarkLevelAsCompleted(levelIndex); // Mark level as completed and unlock the next one
            }
            else
            {
                audioManager.PlaySFX(audioManager.popUpSoundsad);
                tryAgainPopup.SetActive(true);
            }

            foreach (Toggle toggle in answerToggles)
            {
                toggle.interactable = false;
            }

            examFinished = true;
        }
    }

    void OnExamTimeUp()
    {
        audioManager.PlaySFX(audioManager.popUpSoundsad);
        tryAgainPopup.SetActive(true);

        foreach (Toggle toggle in answerToggles)
        {
            toggle.interactable = false;
        }

        examFinished = true;
    }

    public void ResetExam()
    {
        congratsPopup.SetActive(false);
        tryAgainPopup.SetActive(false);

        foreach (Toggle toggle in answerToggles)
        {
            toggle.isOn = false;
            toggle.interactable = true;
        }

        timer = examDuration;
        examFinished = false;
        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = string.Format("TIMER: {0:00}:{1:00}", minutes, seconds);
    }
}
