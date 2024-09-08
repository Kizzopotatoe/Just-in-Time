using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public int currentlyHolding = 0;        //How many civilians the player is currently holding
    public GameObject[] heldCivilians;      //Reference to the civilian game objects

    private void OnCollisionEnter(Collision collision)
    {
        //If the player collides with a civilian, the number they are holding will increase
        if (collision.gameObject.CompareTag("Civilian"))
        {
            if(currentlyHolding >= 2) return;

            Destroy(collision.gameObject);

            heldCivilians[currentlyHolding].SetActive(true);

            currentlyHolding++;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //If the player collides with the drop point, they will drop off all the civilians
        //they are currently holding, and the counter will reduce to 0
        if (other.gameObject.CompareTag("DropPoint"))
        {
            heldCivilians[0].SetActive(false);
            heldCivilians[1].SetActive(false);

            currentlyHolding = 0;
        }
    }
}
