using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class ActivateEvents : MonoBehaviour
{
    [SerializeField] private List<Events> events;

    public void ActivateEventNum(int n)
    {
        events[n].Event.Invoke();
    }

    public void ActivateEventStr(string s)
    {
        for (int i = 0; i < events.Count; i++)
        {
            if (events[i].EventName == s)
            {
                events[i].Event.Invoke();
                return;
            }
        }
    }
}
[System.Serializable]
public class Events 
    {
         public string EventName;
         public UnityEvent Event;
    }
