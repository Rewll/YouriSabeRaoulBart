using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomEvent : MonoBehaviour
{
    [SerializeField] private List<EventsList> events;

    public void PickRandomEvent()
    {
        events[Random.Range(0, events.Count)].Outcome.Invoke();
    }

}

[System.Serializable]
public class EventsList
{
    [SerializeField] private string name;
    public UnityEvent Outcome;
}
