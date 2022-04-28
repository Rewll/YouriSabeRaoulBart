using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class StartEventScript : MonoBehaviour
{

    [Header("StartEvent")]
    [SerializeField] private UnityEvent startEvent;
    void Start()
    {
        startEvent.Invoke();
    }
}
