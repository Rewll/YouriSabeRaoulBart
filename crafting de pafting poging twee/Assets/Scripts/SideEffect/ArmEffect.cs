using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmEffect : AbstactSideEffect
{
    float amount = 0;
    public override void DrinkEffect()
    {
        Debug.Log("ArmSpeed " + amount.ToString());
    }

    public override void EffectCount(float addedAmount)
    {
        amount += addedAmount;
        //Debug.Log(amount);
    }

    public override void ThrowEffect()
    {
        Debug.Log("GooiArm " + amount.ToString());
    }
}
