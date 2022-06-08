using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFlowersAndTheBeesEffect : AbstractMainEffect
{
    private GameObject player;
    private GameObject pollenObject;

    private void Awake()
    {
        player = GameObject.Find("Player");
        pollenObject = Resources.Load<GameObject>("Prefabs/FlowerPollen");
    }
    public override void DrinkEffect()
    {
        if (!player.GetComponent<PlayerBeeAblity>())
        {
            var temp = player.AddComponent<PlayerBeeAblity>();
        }
        else 
        {
            player.GetComponent<PlayerBeeAblity>().AddLengthTime();
        }
    }

    public override void ThrowEffect()
    {
        Instantiate(pollenObject,transform.position,Quaternion.identity);       
    }
}
