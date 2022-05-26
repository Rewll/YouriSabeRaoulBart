using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PollenEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent pollenActivate;
    public void PollenActivate()
    {
        pollenActivate.Invoke();
    }
}
