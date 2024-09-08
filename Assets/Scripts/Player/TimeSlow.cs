using UnityEngine;

public class TimeSlow : MonoBehaviour
{
    public bool timeSlowed;
    public float slowTimer = 5f;

    public GameEvent slowed;
    public GameEvent unslowed;

    // Start is called before the first frame update
    void Start()
    {
        timeSlowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && timeSlowed == false && slowTimer > 0)
        {
            slowed.Raise();
            timeSlowed = true;

            Debug.Log("Time Slowed");
        }

        if(timeSlowed == true)
        {
            slowTimer -= Time.deltaTime;
        }

        if(slowTimer <= 0f && timeSlowed == true)
        {
            unslowed.Raise();
            timeSlowed = false;

            Debug.Log("Time Unslowed");
        }
    }
}
