using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject levelCompleteMenu;
    public GameObject levelFailedMenu;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        { 
            Destroy(gameObject);
        }
    }
}
