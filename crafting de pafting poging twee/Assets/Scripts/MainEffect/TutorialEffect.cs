using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEffect : AbstractMainEffect
{
    GameObject player;
    GameObject Portaal;

    private void Awake()
    {
        player = GameObject.Find("Player");
        Portaal = Resources.Load<GameObject>("Prefabs/Portaal");
    }

    public override void DrinkEffect()
    {
        player.transform.GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(1).gameObject.SetActive(true);
        Instantiate(Resources.Load<GameObject>("Prefabs/SpelerECHT(nep)"), GameObject.Find("SpelerECHTPOS").transform.position, Quaternion.identity);
    }

    public override void ThrowEffect()
    {
        Instantiate(Portaal, transform.position, Quaternion.identity);
    }
}