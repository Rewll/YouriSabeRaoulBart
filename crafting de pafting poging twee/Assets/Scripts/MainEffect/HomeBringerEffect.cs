using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBringerEffect : AbstractMainEffect
{
    private GameObject birdPrefab;
    private GameObject player;

    private void Awake()
    {
        birdPrefab = Resources.Load<GameObject>("Prefabs/Bird");
        player = GameObject.Find("Player");
    }
    public override void DrinkEffect()
    {
        player.AddComponent<PlayerHomeAbility>();
    }


    public override void ThrowEffect()
    {
        Instantiate(birdPrefab, transform.position, Quaternion.identity);
    }
}
