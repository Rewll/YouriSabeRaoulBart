using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public bool isTouching = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Untagged"))
        {
            isTouching = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        isTouching = false;
    }
}
