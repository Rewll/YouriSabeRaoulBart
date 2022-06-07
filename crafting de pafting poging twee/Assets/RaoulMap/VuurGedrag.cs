using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VuurGedrag : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(fikken());   
    }

    IEnumerator fikken()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<verbrandbaarObject>())
        {
            collision.GetComponent<verbrandbaarObject>().Brand();
        }    
    }
}
