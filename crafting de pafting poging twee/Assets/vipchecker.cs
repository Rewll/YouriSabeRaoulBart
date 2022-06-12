using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class vipchecker : MonoBehaviour
{
    [SerializeField] private UnityEvent Open;
    [SerializeField] private UnityEvent Close;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.position.y > transform.position.y && collision.CompareTag("Player") || collision.GetComponent<PlayerVipAbility>())
        {
            Open.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        { 
        Close.Invoke();
        }
    }
}
