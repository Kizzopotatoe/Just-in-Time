using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlow : MonoBehaviour
{
    public float maxSlowTimer = 10f;
    [SerializeField] private float slowTimer;
    [SerializeField] private TextMeshProUGUI slowText;
    [SerializeField] private GameObject slowMoEffect;
    public Slider slider;
    public bool timeSlowed;

    //Reference to game events
    public GameEvent slowed;
    public GameEvent unslowed;

    // Start is called before the first frame update
    void Start()
    {
        slowTimer = 5;
        slider.maxValue = maxSlowTimer;

        timeSlowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        slowText.text = slowTimer.ToString("0.0");
        slider.value = slowTimer;

        //If the player holds shift, the time slow event will be raised
        if(Input.GetKeyDown(KeyCode.LeftShift) && timeSlowed == false && slowTimer > 0)
        {
            slowed.Raise();
            timeSlowed = true;
            slowMoEffect.SetActive(true);

            Debug.Log("Time Slowed");
        }

        //After time is slowed, the slow timer will start to tick down
        if(timeSlowed == true)
        {
            slowTimer -= Time.deltaTime;
        }

        //When the slow timer reaches zero/ the player releases shift, the unslow event will be raised
        if(slowTimer <= 0f || Input.GetKeyUp(KeyCode.LeftShift))
        {
            unslowed.Raise();
            timeSlowed = false;
            slowMoEffect.SetActive(false);

            Debug.Log("Time Unslowed");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If the player collides with a minion, it will be destroyed and add 5 to the players slow timer
        if (collision.gameObject.CompareTag("Minion"))
        {
            Destroy(collision.gameObject);
            slowTimer += 5f;

            if(slowTimer >= maxSlowTimer)
            {
                slowTimer = maxSlowTimer;
            }
        }
    }
}
