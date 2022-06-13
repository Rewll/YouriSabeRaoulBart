using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IngredientTrigger : MonoBehaviour
{
    public UnityEvent triggerEnter;
    public UnityEvent triggerEnter2;
    public UnityEvent textOutFadeEvent;

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
        textOutFadeEvent.Invoke();
        yield return new WaitForSeconds(2);
        triggerEnter2.Invoke();
    }
}