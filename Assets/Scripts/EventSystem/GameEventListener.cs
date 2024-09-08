using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    GameEvent gameEvent;        //This is the event S.O. we will OBSERVE
    [SerializeField]
    UnityEvent response;            //This will be the response executed when the event is raised

    private void OnEnable()
    {
        //Registers the listener
        gameEvent.RegisterListeners(this);
    }

    private void OnDisable()
    {
        //Unregisters the listener
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        //The ? checks if response is not equal to null. If it is not, Invoke() the response.
        response?.Invoke();
    }
}
