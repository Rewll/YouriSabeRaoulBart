using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StawHouse : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);
        if (collision.CompareTag("WindAblility")) 
        {
            animator.Play("StrowKapot");
            Debug.Log("omgewaait");
        }
    }
}
