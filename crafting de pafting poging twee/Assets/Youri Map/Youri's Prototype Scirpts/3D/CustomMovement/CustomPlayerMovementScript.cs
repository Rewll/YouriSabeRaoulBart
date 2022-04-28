using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class CustomPlayerMovementScript : MonoBehaviour
{
    private Rigidbody rb;

    [Header("settings")]
    [SerializeField] private bool isOn = true;
    [SerializeField] private bool usingYVelocity;
    [Header("Stats")]
    [SerializeField] private float speed;

    private Vector3 Movement;
    private float veloX;
    private float veloY;
    private float veloZ;

    void Start()
    {
            rb = this.gameObject.GetComponent<Rigidbody>();
    }

    public void ChangeX(float inputValue)
    {
        veloX = inputValue * speed;
    }

    public void ChangeY(float inputValue)
    {
        veloY = inputValue * speed; 
    }

    public void ChangeZ(float inputValue)
    {
        veloZ = inputValue * speed;
    }

    public void TurnOnOff(bool turnOn)
    {
        turnOn = isOn;
    }

    void Update()
    {
        if(isOn)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        if(usingYVelocity)
        {
            Movement = new Vector3(veloX, veloY, veloZ);
        }
        else
        {
            Movement = new Vector3(veloX, rb.velocity.y, veloZ);
        }

        rb.velocity = Movement;
    }
}
