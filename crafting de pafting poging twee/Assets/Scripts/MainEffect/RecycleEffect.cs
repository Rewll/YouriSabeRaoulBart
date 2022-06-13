using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleEffect : AbstractMainEffect
{
    private GameObject[] ingredients;
    private GameObject player;

    public void Awake()
    {
        player = GameObject.Find("Player");
    }
    public override void DrinkEffect()
    {
        foreach (var item in ingredients)
        {
            Instantiate(item, player.transform.position + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0), Quaternion.identity);
        }
    }

    public override void ThrowEffect()
    {
        foreach (var item in ingredients)
        {
            Instantiate(item, transform.position + new Vector3(Random.Range(-1.0f,1.0f), Random.Range(-1.0f, 1.0f),0), Quaternion.identity);
        }
    }

    public void IngriedientFiller(GameObject[] newIng) 
    {
        ingredients = newIng;
    }
}
