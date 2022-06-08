using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientGenerator : MonoBehaviour
{
    public GameObject ingredientPrefab;
    public int minimumIngredientAantal;
    public List<GameObject> ingredientenVanDezeFabriek = new List<GameObject>();
    
    SpriteRenderer spriteRenderaar;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderaar = GetComponent<SpriteRenderer>();
        spriteRenderaar.color = new Color(0, 0, 0, 0);
        startGeneratie();
    }

    void startGeneratie()
    {
        for (int i = 0; i < minimumIngredientAantal; i++)
        {
            instantieerIngredient();
        }
    }

    public void instantieerIngredient()
    {
        //Debug.Log("ingredient ge-instantieerd");
        GameObject nieuwIngredient = Instantiate(ingredientPrefab, WillekeurigPuntInGrenzen(), Quaternion.identity);
        ingredientenVanDezeFabriek.Add(nieuwIngredient);
        nieuwIngredient.GetComponent<Ingredient>().ING = GetComponent<IngredientGenerator>();
    }


    public Vector2 WillekeurigPuntInGrenzen()
    {
        return new Vector2(
            Random.Range(spriteRenderaar.bounds.min.x, spriteRenderaar.bounds.max.x),
            Random.Range(spriteRenderaar.bounds.min.y, spriteRenderaar.bounds.max.y));
    }

}