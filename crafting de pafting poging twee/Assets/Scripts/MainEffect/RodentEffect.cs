using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodentEffect : AbstractMainEffect
{
    private GameObject egelPrefab;
    private GameObject player;

    private void Awake()
    {
        egelPrefab = Resources.Load<GameObject>("Prefabs/MeneerEgel");
        player = GameObject.Find("Player");
    }

    public override void DrinkEffect()
    {
        if (!player.GetComponent<PlayerShrinkAbility>())
        {
            var temp = player.AddComponent<PlayerShrinkAbility>();
        }
        else
        {
            player.GetComponent<PlayerShrinkAbility>().AddLengthTime();
        }
    }

    public override void ThrowEffect()
    {
        Instantiate(egelPrefab, transform.position,Quaternion.identity);
    }

}
