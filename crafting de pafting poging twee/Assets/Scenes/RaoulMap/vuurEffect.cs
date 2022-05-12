using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VuurEffect : AbstractMainEffect
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
            player.AddComponent<SpelerVuur>();
        }
        else
        {
            player.GetComponent<SpelerVuur>().spelerWordtLangerHeet();
        }
    }

    public override void ThrowEffect()
    {
        //Debug.Log("Speler gooit vuur");
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(vuurprefab, worldPosition, Quaternion.identity);
    }
}