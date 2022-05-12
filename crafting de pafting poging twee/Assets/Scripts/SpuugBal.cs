using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpuugBal : MonoBehaviour
{
    private Vector3 shootVelo;
    private Rigidbody2D rb2D;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();      
    }

    public void Shoot(Vector3 newShootVelo) 
    {
        shootVelo = newShootVelo;
    }

    private void Update()
    {
        rb2D.velocity = shootVelo;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ingredient") || collision.CompareTag("Potion")) 
        {
            return;
        }
        if (collision.CompareTag("Player")) 
        {
            Debug.Log("SpelerGeraakt");
        }
        Destroy(gameObject);
    }
}
