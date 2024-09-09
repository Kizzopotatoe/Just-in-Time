using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool isPaused = false;

    private void Update()
    {
        if (GameManager.instance.levelCompleteMenu.activeSelf) return;

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused) 
            {
                Resume();
            }
            else 
            { 
               Pause(); 
            }
        }
    }

    private void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    
    private void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        GameManager.instance.RetryLevel();

    }
}
