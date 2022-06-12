using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IngredientTrigger : MonoBehaviour
{
    public UnityEvent triggerEnter;
    public UnityEvent triggerEnter2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ingredient"))
        {
            triggerEnter.Invoke();
        }
        if (collision.gameObject.name == "Deksel")
        {
            Debug.Log("Log");
            StartCoroutine(stupidCode());
        }
    }

    IEnumerator stupidCode()
    {
        yield return new WaitForSeconds(7);
        triggerEnter2.Invoke();
    }
}