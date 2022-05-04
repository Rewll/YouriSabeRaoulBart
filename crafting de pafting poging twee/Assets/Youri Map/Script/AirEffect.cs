using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEffect : AbstactMainEffect
{
    private GameObject bubblePrefab;

    private void Awake()
    {
        bubblePrefab = Resources.Load<GameObject>("Prefabs/BubblePrefab");
    }

    public override void DrinkEffect()
    {
        throw new System.NotImplementedException();
    }

    public override void ThrowEffect()
    {
        Instantiate(bubblePrefab,transform.position,transform.rotation);
    }
}
