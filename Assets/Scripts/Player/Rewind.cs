using UnityEngine;
using UnityEngine.SceneManagement;

public class Rewind : MonoBehaviour
{
    public GameObject rewindPoint;
    private float heldTime = 0f;
    private float timetoHold = 5f;
    public AudioSource source;

    void Awake()
    {
        rewindPoint = GameObject.FindGameObjectWithTag("RewindPoint");

        this.transform.position = rewindPoint.transform.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            source.Play();
        }
        if(Input.GetKeyUp(KeyCode.R))
        {
            source.Stop();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.R))
        {
            heldTime+=0.1f;
        }
        if(Input.GetKeyUp(KeyCode.R) && heldTime < timetoHold)
        {
            heldTime = 0f;
            return;
        }
        if(heldTime >= timetoHold)
        {
            rewindPoint.transform.position = this.transform.position;

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
