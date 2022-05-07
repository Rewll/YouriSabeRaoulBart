using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightEffect : AbstactMainEffect
{
    public GameObject potionEffect;
    public GameObject textObject;
    public GameObject angryMan;
    public GameObject angryManText;
    public GameObject houseLightsOff;
    public GameObject houseLightsOn;

    public override void DrinkEffect()
    {
        potionEffect.SetActive(true);
        textObject.SetActive(false);
        angryMan.SetActive(false);
        angryManText.SetActive(false);
        houseLightsOff.SetActive(false);
        houseLightsOn.SetActive(true);
        Destroy(this.gameObject);
    }

    public override void ThrowEffect()
    {
        throw new System.NotImplementedException();
    }
}
