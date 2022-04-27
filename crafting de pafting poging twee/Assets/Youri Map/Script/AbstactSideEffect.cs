using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstactSideEffect : MonoBehaviour, ISideEffect
{
    public abstract void DrinkEffect();
    public abstract void EffectCount(float addedAmount);
    public abstract void ThrowEffect();
}
