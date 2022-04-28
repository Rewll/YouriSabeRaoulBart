    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2DScript : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("settings")]
    [SerializeField] private bool isOn = true;
    [SerializeField] private bool usingYVelocity;
    [Header("Stats")]
    [SerializeField] private float speed;

    private Vector2 Movement;
    private float veloX;
    private float veloY;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    public void ChangeX(float inputValue)
    {
        veloX = inputValue * speed;
    }

    public void ChangeY(float inputValue)
    {
        veloY = inputValue * speed;
    }

    public void TurnOnOff(bool turnOn)
    {
        turnOn = isOn;
    }

    void Update()
    {
        if (isOn)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        if (usingYVelocity)
        {
            Movement = new Vector2(veloX, veloY);
        }
        else
        {
            Movement = new Vector2(veloX, rb2D.velocity.y);
        }

        rb2D.velocity = Movement;
    }
}
