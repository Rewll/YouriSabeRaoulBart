using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMagnetEffect : AbstractMainEffect
{
    private GameObject player;
    private GameObject lichaam;
    private PotionClass potionClass;
    private bool toggle;
    private GameObject teleportAwayParticle;
    private GameObject teleportBackinParticle;
    private void Awake()
    {
        player = GameObject.Find("Player");
        //lichaam = player.transform.GetChild(0).transform.GetChild(0).gameObject;
        potionClass = gameObject.GetComponent<PotionClass>();
        teleportAwayParticle = Resources.Load<GameObject>("Prefabs/TeleportAway");
        teleportBackinParticle = Resources.Load<GameObject>("Prefabs/TeleportBackIn");
    }
    public override void DrinkEffect()
    {
        throw new System.NotImplementedException();
    }

    public override void ThrowEffect()
    {
        var temp = Instantiate(teleportBackinParticle, player.transform);
        player.transform.position = gameObject.transform.position;
        temp.transform.parent = null;
        player.SetActive(true);
    }

    private void Update()
    {
        if(potionClass.wordtGegooid && !toggle) 
        {
            Instantiate(teleportAwayParticle, transform);
            toggle = true;
            player.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
