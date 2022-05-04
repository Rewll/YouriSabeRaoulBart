using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] private PotionIngredient potionIngredientSO;
    [SerializeField] private PlayerMovement playerMovement;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cauldron"))
        {
            var Script = collision.gameObject.GetComponent<Cauldron>();
            Script.AddIngredient(potionIngredientSO);
            playerMovement.inHand1 = false;
            Destroy(gameObject);
        }
    }



}
