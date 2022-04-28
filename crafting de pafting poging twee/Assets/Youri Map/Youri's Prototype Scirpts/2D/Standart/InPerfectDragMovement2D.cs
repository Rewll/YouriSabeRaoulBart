using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class InPerfectDragMovement2D : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool isOn = true;
    
    private Vector3 mousepos;
    private Camera mainCamera;
    private Vector3 Velocity;
    private Vector3 Ofset;
    private Rigidbody2D rb2D;

    private void Awake()
    {
        mainCamera = Camera.main;
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        Ofset = transform.position - mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Ofset.z = 0;
    }

    private void OnMouseDrag()
    {
        if (isOn) 
        {
            Velocity = (mainCamera.ScreenToWorldPoint(Input.mousePosition) - this.gameObject.transform.position + Ofset) * speed;
            rb2D.velocity = Velocity;
        }
    }

    public void ToggleOnOff()
    {
        isOn = !isOn;
    }

}
