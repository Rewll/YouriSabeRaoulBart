using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class egelfik : MonoBehaviour
{
    [SerializeField] private UnityEvent onFire;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire")) 
        {
            onFire.Invoke();
        }
    }
}
