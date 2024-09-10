using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 5f;
    [SerializeField] private TextMeshProUGUI timerText;
    public Slider slider;
    private bool timeSlowed;

    [SerializeField] private VillainManager villainManager;

    private void Start()
    {
        slider.maxValue = timeRemaining;
    }

    private void Update()
    {
        slider.value = timeRemaining;

        if(timeRemaining > 0 && timeSlowed == false)
        {
            timeRemaining -= Time.deltaTime;

            if(timeRemaining >= 60)
            {
                ShowMinutesAndSeconds(); // Shows the timer in a minutes and seconds format
            }
            else
            {
                ShowSecondsOnly(); // Changes the format to be seconds only
            }
        
        }
        if(timeRemaining > 0 && timeSlowed == true)
        {
            timeRemaining -= Time.deltaTime / 3;

            if(timeRemaining >= 60)
            {
                ShowMinutesAndSeconds(); // Shows the timer in a minutes and seconds format
            }
            else
            {
                ShowSecondsOnly(); // Changes the format to be seconds only
            }
        
        }
        if(timeRemaining <= 0)
        {
            LevelFailed();
        }
    }

    private void ShowMinutesAndSeconds()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60); // divide by 60 to get minutes
        int seconds = Mathf.FloorToInt(timeRemaining % 60); // Get the remainder for seconds

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void ShowSecondsOnly()
    {
        timerText.text = timeRemaining.ToString("0.0");
    }

    void LevelFailed()
    {
        if(villainManager != null)
        {
            villainManager.EndSequence();
        }
        else
        {
            GameManager.instance.levelFailedMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void TimeSlow()
    {
        timeSlowed = true;
    }
    public void TimeUnslow()
    {
        timeSlowed = false;
    }
}
