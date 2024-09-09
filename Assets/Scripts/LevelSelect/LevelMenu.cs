using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0;i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void Openlevel(int levelId)
    {
        // how scenes are named
        string levelName = "Level_" + levelId;
        SceneManager.LoadScene(levelName);
    }
}
