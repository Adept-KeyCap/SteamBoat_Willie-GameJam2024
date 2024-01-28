using TMPro;
using UnityEngine;

public class Chronometer : MonoBehaviour
{
    [Header("Chronometer Parameters")]
    [SerializeField] private TextMeshProUGUI timerText;

    private float startTime;
    private float pausedTime;
    public bool isPaused = false;

    [SerializeField] private float timeScale = 1f; // Default to 1
    private int minutes;
    private int seconds;

    [SerializeField] private GameObject cat;
    private Animator animCat;
    private GameManager gameManager;

    [SerializeField] private float playfulTime;
    [SerializeField] private float catWinTime;

    private AudioManager audioManager;

    //private CatCheesyManager cat;
    void Start()
    {
        animCat = cat.GetComponent<Animator>();
        StartChronometer();
        gameManager = gameObject.GetComponent<GameManager>();
        audioManager = FindFirstObjectByType<AudioManager>();

    }

    void Update()
    {
        if (!isPaused)
        {
            float currentTime = Time.time - startTime + pausedTime;
            DisplayTime(currentTime);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                PauseGame();
            else
                ResumeGame();
        }

    }

    private void DisplayTime(float timePassed)
    {
        minutes = Mathf.FloorToInt(timePassed / 60);
        seconds = Mathf.FloorToInt(timePassed % 60);

        if(minutes >= playfulTime){
            animCat.SetBool("IsPlayful", true);
            audioManager.Play_catEvilLaugh_SFX();
        }

        if(minutes >= catWinTime){
            gameManager.OnCatWin();
        }

        string timeText = minutes.ToString("00") + ":" + seconds.ToString("00");
        timerText.text = timeText;
    }

    public void StartChronometer()
    {
        startTime = Time.time;
        isPaused = false;
    }

    private void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f; // Pause the game
            pausedTime += Time.time - startTime;
            isPaused = true;
        }
    }

    private void ResumeGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1f; // Resume the game
            startTime = Time.time;
            isPaused = false;
        }
    }

    public void ResetChronometer()
    {
        Time.timeScale = 1f; // Ensure time scale is back to normal when resetting
        startTime = Time.time;
        pausedTime = 0f;
        isPaused = false;
        DisplayTime(0);
    }
}
