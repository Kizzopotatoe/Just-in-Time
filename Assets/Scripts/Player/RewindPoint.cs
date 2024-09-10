using UnityEngine;

public class RewindPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
