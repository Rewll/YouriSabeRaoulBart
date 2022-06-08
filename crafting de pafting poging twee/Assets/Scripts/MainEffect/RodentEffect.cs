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
        throw new System.NotImplementedException();
    }

    public override void ThrowEffect()
    {
        Instantiate(egelPrefab, transform.position, transform.rotation);
    }

}
