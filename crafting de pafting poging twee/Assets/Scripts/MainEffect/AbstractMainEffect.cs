using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMainEffect : MonoBehaviour,IMainEffect
{
    public abstract void DrinkEffect();

    public abstract void ThrowEffect();
}
