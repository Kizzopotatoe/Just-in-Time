using UnityEngine;
using TMPro;

public class PlayerGrab : MonoBehaviour
{
    public int currentlyHolding = 0;        //How many civilians the player is currently holding
    public int droppedOff = 0;
    public GameObject[] heldCivilians;      //Reference to the civilian game objects

    [SerializeField] private TextMeshProUGUI civiliansRemainingText; // on the car gameobject - world space canvas
    [SerializeField] private TextMeshProUGUI civiliansSavedTextWhenComplete;
    [SerializeField] private TextMeshProUGUI civiliansSavedTextWhenFail;

    private int totalCivilians;
    private int civiliansRemaining;

    public AudioSource ding;
    public AudioSource bump;

    private void Start()
    {
        totalCivilians = GameObject.FindGameObjectsWithTag("Civilian").Length;
        civiliansRemaining = totalCivilians;
        UpdateCivilianCounter();

    }

    private void OnCollisionEnter(Collision collision)
    {
        //If the player collides with a civilian, the number they are holding will increase
        if (collision.gameObject.CompareTag("Civilian"))
        {
            if(currentlyHolding >= 2) return;

            Destroy(collision.gameObject);
            heldCivilians[currentlyHolding].SetActive(true);

            bump.Play();

            currentlyHolding++;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //If the player collides with the drop point, they will drop off all the civilians
        //they are currently holding, and the counter will reduce to 0
        if (other.gameObject.CompareTag("DropPoint"))
        {
            if(currentlyHolding == 1)
            {
                heldCivilians[0].SetActive(false);

                currentlyHolding = 0;
                
                ding.Play();

                droppedOff++;
                civiliansRemaining--;
            }
            else if(currentlyHolding == 2)
            {
                heldCivilians[0].SetActive(false);
                heldCivilians[1].SetActive(false);

                currentlyHolding = 0;

                ding.Play();

                droppedOff += 2;
                civiliansRemaining -= 2;
            }

            UpdateCivilianCounter();
        }

    }

    private void UpdateCivilianCounter()
    {
        civiliansRemainingText.text = civiliansRemaining.ToString();
        civiliansSavedTextWhenComplete.text = droppedOff.ToString();
        civiliansSavedTextWhenFail.text = droppedOff.ToString();
    }
}
