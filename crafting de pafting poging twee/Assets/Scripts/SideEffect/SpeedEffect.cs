using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffect : AbstactSideEffect
{
    float amount = 0;
    public override void DrinkEffect()
    {
        Debug.Log("DrinkSpeed " + amount.ToString());
    }
    public override void EffectCount(float addedAmount)
    {
        amount += addedAmount;
        //Debug.Log(amount);
    }
    public override void ThrowEffect()
    {
        Debug.Log("GooiSpeed " + amount.ToString());
    }
}
