using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverEffect : AbstractMainEffect
{
    private GameObject player;

    public void Awake()
    {
        player = GameObject.Find("Player");
    }

    public override void DrinkEffect()
    {
        //Debug.Log("Speler drinkt bever");
        if (!player.GetComponent<PlayerBeverAbility>())
        {
            var temp = player.AddComponent<PlayerBeverAbility>();
        }
        else
        {
            player.GetComponent<PlayerBeverAbility>().langerBever();
        }
    }

    public override void ThrowEffect()
    {
        
    }
}