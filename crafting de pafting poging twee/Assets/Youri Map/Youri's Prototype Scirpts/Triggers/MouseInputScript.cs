using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseInputScript : MonoBehaviour
{

    [Header("Events")]
    [SerializeField] private UnityEvent onMouseDown;
    [SerializeField] private UnityEvent onMouseUp;
    [SerializeField] private UnityEvent onMouseDrag;
    [SerializeField] private UnityEvent onMouseEnter;
    [SerializeField] private UnityEvent onMouseExit;
    [SerializeField] private UnityEvent onMouseOver;

    private void OnMouseDown()
    {
        onMouseDown.Invoke();
    }

    private void OnMouseUp()
    {
        onMouseUp.Invoke();
    }

    private void OnMouseDrag()
    {
        onMouseDrag.Invoke(); 
    }

    private void OnMouseEnter()
    {
        onMouseEnter.Invoke();
    }

    private void OnMouseExit()
    {
        onMouseExit.Invoke();
    }

    private void OnMouseOver()
    {
        onMouseOver.Invoke();
    }
}
