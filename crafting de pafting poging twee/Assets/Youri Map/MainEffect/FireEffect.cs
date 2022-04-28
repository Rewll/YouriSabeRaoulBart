using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : AbstactMainEffect
{
    public override void DrinkEffect()
    {
        Debug.Log("Vuur in keelgat");
    }

    public override void ThrowEffect()
    {
        Debug.Log("Vuur aan de overkant");
    }
}
