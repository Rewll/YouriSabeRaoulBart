using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] private PotionIngredient potionIngredientSO;
    [SerializeField] private GameObject player;
    public IngredientGenerator ING;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cauldron"))
        {
            var Script = collision.gameObject.GetComponent<Cauldron>();
            Script.AddIngredient(potionIngredientSO);
            player.GetComponent<PlayerMovement>().inHand1 = false;
            if (ING) 
            { 
            ING.ingredientenVanDezeFabriek.Remove(this.gameObject);
            ING.instantieerIngredient();
            }
            Destroy(gameObject);
        }
    }
}