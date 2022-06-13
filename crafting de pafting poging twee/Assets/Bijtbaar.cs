using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bijtbaar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tanden"))
        {
            Destroy(gameObject);
        }
    }
}
