using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongFestivalEffect : AbstractMainEffect
{
    private GameObject songFestivalPrefab;
    private GameObject player;

    private void Awake()
    {
        songFestivalPrefab = Resources.Load<GameObject>("Prefabs/SongFestival2010");
        player = GameObject.Find("Player");
    }
    public override void DrinkEffect()
    {
        player.AddComponent<PlayerVipAbility>();
    }

    public override void ThrowEffect()
    {
        Instantiate(songFestivalPrefab, transform.position, Quaternion.identity);
    }
}
