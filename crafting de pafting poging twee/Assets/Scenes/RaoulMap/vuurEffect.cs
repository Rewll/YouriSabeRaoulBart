using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vuurEffect : AbstactMainEffect
{
    private GameObject player;
    GameObject vuurprefab;

    private void Awake()
    {
        player = GameObject.Find("Player");
        vuurprefab = Resources.Load<GameObject>("Prefabs/Vuur");
    }

    public override void DrinkEffect()
    {
        Debug.Log("Speler drinkt vuur");
        if (!player.GetComponent<SpelerVuur>())
        {
            var temp = player.AddComponent<SpelerVuur>();
        }
        player.GetComponent<SpelerVuur>().SpelerIsHeet();
    }

    public override void ThrowEffect()
    {
        Debug.Log("Speler gooit vuur");
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(vuurprefab, worldPosition, Quaternion.identity);
    }
}
