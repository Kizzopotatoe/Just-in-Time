using UnityEngine;

public class DropOffPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < trigger.transform.childCount; i++)
            {
                Transform child = trigger.transform.GetChild(i);

                if (child.CompareTag("Civilian"))
                {
                    child.parent = null;
                }

                if(child.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    rb.isKinematic = false;
                }
                if(child.TryGetComponent<Collider>(out Collider col))
                {
                    col.isTrigger = false;
                }

                Debug.Log("Civilian dropped off");
            }

        }
    }
}
