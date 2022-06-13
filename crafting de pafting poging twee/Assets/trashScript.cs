using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashScript : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MagnetAblity")) 
        {
            rb2D.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MagnetAblity"))
        {
            rb2D.velocity = Vector2.zero;
            rb2D.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
