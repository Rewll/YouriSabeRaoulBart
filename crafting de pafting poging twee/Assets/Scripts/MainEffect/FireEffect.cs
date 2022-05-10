using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireEffect : AbstractMainEffect
{
    public bool gooien;

    public override void DrinkEffect()
    {
        Debug.Log("Vuur in keelgat");
        Application.Quit();
    }

    public override void ThrowEffect()
    {
        Debug.Log("Vuur aan de overkant");
        gooien = true;
        Invoke("ductapeWHOEOE", 1f);
    }

    public void ductapeWHOEOE()
    {
        Destroy(gameObject);
    }
}