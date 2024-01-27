using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Chronometer : MonoBehaviour
{
    [Header("Chronometer Parameters")]
    [SerializeField] private TextMeshProUGUI timerText; // Reference to the Text component where the timer will be displayed

    private float startTime;
    private float pausedTime;
    private bool isPaused = false;

    [SerializeField] private float timeScale;
    private int minutes;
    private int seconds;

    void Start()
    {
        StartChronometer();
    }

    void Update()
    {
        if (!isPaused)
        {
            float currentTime = Time.time - startTime - pausedTime;
            if (timeScale > 0)
            {
                currentTime = (Time.time - startTime - pausedTime) * timeScale;
                DisplayTime(currentTime);
            }
            else
            {
                DisplayTime(currentTime);
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PauseChronometer();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            ResumeChronometer();
        }
    }

    private void DisplayTime(float timePassed)
    {
        minutes = Mathf.FloorToInt(timePassed / 60);
        seconds = Mathf.FloorToInt(timePassed % 60);

        // Format the time as "00:00"
        string timeText = minutes.ToString("00") + ":" + seconds.ToString("00");

        timerText.text = timeText;
    }

    public void StartChronometer()
    {
        startTime = Time.time;
        isPaused = false;
    }

    public void PauseChronometer()
    {
        if (!isPaused)
        {
            pausedTime += Time.time - startTime;
            isPaused = true;
        }
    }

    public void ResumeChronometer()
    {
        if (isPaused)
        {
            startTime = Time.time;
            isPaused = false;
        }
    }

    public void ResetChronometer()
    {
        startTime = Time.time;
        pausedTime = 0f;
        isPaused = false;
        DisplayTime(0);
    }

    private void TimeWinner()
    {
        if(minutes > 5)
        {
            Debug.Log("Cat wins");
        }
    }
}