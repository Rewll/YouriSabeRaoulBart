using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFlowersAndTheBeesEffect : IMainEffect
{
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    public void DrinkEffect()
    {
        if (!player.GetComponent<PlayerBlowAbility>())
        {
            var temp = player.AddComponent<PlayerBlowAbility>();
        }
    }

    public void ThrowEffect()
    {
        throw new System.NotImplementedException();
    }
}
