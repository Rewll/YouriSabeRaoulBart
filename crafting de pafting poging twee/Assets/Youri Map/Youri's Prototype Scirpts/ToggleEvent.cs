using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleEvent : MonoBehaviour
{
    private bool toggle = false;
    [SerializeField] private UnityEvent eventA;
    [SerializeField] private UnityEvent eventB;

    public void EventToggle() 
    {
        toggle = !toggle;

        if (toggle)
        {
            eventA.Invoke();
            return;
        }

        if (!toggle) 
        {
            eventB.Invoke();
            return;
        }
    } 
}
