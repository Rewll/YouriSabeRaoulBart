using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollenator : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Die());
    }

    IEnumerator Die() 
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var temp = collision.gameObject.GetComponent<PollenEvent>();
        if (temp)
        {
            temp.PollenActivate();
        }
    }
}
