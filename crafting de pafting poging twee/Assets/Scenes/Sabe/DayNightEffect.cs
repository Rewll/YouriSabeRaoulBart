using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightEffect : AbstactMainEffect
{
    GameManagerSO managerSO;

    private void Awake()
    {
        managerSO = Resources.Load<GameManagerSO>("ScriptableObjects/GameManagerSO");
    }

    public override void DrinkEffect()
    {
        managerSO.night = !managerSO.night;
    }

    public override void ThrowEffect()
    {
        throw new System.NotImplementedException();
    }
}
