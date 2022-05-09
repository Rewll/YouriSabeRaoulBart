using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverEffect : AbstactMainEffect
{
    private GameObject player;

    public void Awake()
    {
        player = GameObject.Find("Player");

    }

    public override void DrinkEffect()
    {
        Debug.Log("Speler drinkt bever");
        if (!player.GetComponent<SpelerBever>())
        {
            var temp = player.AddComponent<SpelerBever>();
        }
    }

    public override void ThrowEffect()
    {
        
    }
}
