using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public interface ISideEffect
{
    void EffectCount(float addedAmount);
    void DrinkEffect();
    void ThrowEffect();
}
