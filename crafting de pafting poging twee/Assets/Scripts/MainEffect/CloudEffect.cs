using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEffect : AbstractMainEffect
{
    GameObject player;
    GameObject cloudPrefab;

    private void Awake()
    {
        player = GameObject.Find("Player");
        cloudPrefab = Resources.Load<GameObject>("Prefabs/CloudPrefab");
    }

    public override void DrinkEffect()
    {
        if (player.GetComponent<CloudEntrance>() == null)
        {
            player.AddComponent<CloudEntrance>();
        }
    }

    public override void ThrowEffect()
    {
        Instantiate(cloudPrefab, transform.position, transform.rotation);
    }

}
