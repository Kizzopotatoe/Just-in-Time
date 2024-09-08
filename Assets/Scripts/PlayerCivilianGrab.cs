using System.Collections.Generic;
using UnityEngine;

public class PlayerCivilianGrab : MonoBehaviour
{
    public Transform[] shoulders;
    private bool[] shouldersOccupied;

    private void Start()
    {
        shouldersOccupied = new bool[shoulders.Length];
    }

    private void Update()
    {
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Civilian"))
        {
            // Find the first available shoulder
            int availableShoulderIndex = -1;
            for (int i = 0; i < shoulders.Length; i++)
            {
                if (!shouldersOccupied[i])
                {
                    availableShoulderIndex = i;
                    break;
                }
            }

            // If there is an available shoulder, attach the civilian
            if (availableShoulderIndex != -1)
            {

                Transform availableShoulder = shoulders[availableShoulderIndex];

                collision.transform.position = availableShoulder.position;
                collision.transform.parent = transform;

                collision.rigidbody.isKinematic = true;
                collision.collider.isTrigger = true;

                // Mark the shoulder as occupied
                shouldersOccupied[availableShoulderIndex] = true;
            }
            else
            {
                Debug.Log("Both shoulders are taken");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // When the player puts down the civilian, it frees up the shoulder 
        if (collision.gameObject.CompareTag("Civilian"))
        {
            for (int i = 0; i < shoulders.Length; i++)
            {
                if (collision.transform.parent == shoulders[i])
                {
                    // Unmark the shoulder as occupied
                    shouldersOccupied[i] = false;
                    collision.transform.parent = null;
                    break;
                }
            }
        }
    }
}
