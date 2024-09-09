using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int scoreToWin;
    public PlayerGrab playerGrab;

    // Start is called before the first frame update
    void Start()
    {
        playerGrab = FindObjectOfType<PlayerGrab>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerGrab.droppedOff >= scoreToWin)
        {
            GameManager.instance.levelCompleteMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
