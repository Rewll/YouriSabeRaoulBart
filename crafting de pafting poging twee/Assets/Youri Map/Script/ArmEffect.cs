using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmEffect : AbstactSideEffect
{
    float amount = 0;
    public override void DrinkEffect()
    {
        throw new System.NotImplementedException();
    }

    public override void EffectCount(float addedAmount)
    {
        amount += addedAmount;
        Debug.Log(amount);
    }

    public override void ThrowEffect()
    {
        throw new System.NotImplementedException();
    }
}
