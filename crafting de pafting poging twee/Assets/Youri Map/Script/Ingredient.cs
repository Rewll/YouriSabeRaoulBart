using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public PotionIngredient potionIngredientSO;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cauldron"))
        {
            var Script = collision.gameObject.GetComponent<Cauldron>();
            Script.AddIngredient(potionIngredientSO);
            Destroy(gameObject);
        }
    }



}
