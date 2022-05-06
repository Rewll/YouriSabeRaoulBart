using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEffect : AbstactMainEffect
{
    private GameObject bubblePrefab;
    private GameObject player;

    private void Awake()
    {
        bubblePrefab = Resources.Load<GameObject>("Prefabs/BubblePrefab");
        player = GameObject.Find("Player");
    }

    public override void DrinkEffect()
    {
        if (!player.GetComponent<PlayerBlowAbility>()) 
        { 
            var temp = player.AddComponent<PlayerBlowAbility>();
        }
    }

    public override void ThrowEffect()
    {
        Instantiate(bubblePrefab,transform.position,transform.rotation);
    }
}
