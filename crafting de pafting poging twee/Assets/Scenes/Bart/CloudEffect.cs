using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEffect : AbstactMainEffect
{
    GameManagerSO managerSO;
    GameObject cloudPrefab;

    private void Awake()
    {
        managerSO = Resources.Load<GameManagerSO>("ScriptableObjects/GameManagerSO");
        cloudPrefab = Resources.Load<GameObject>("Prefabs/CloudPrefab");
    }

    public override void DrinkEffect()
    {
        managerSO.cloudActive = true;
        Invoke("CloudEffectOver", 10f);
    }

    private void CloudEffectOver()
    {
        managerSO.cloudActive = false;
    }

    public override void ThrowEffect()
    {
        Instantiate(cloudPrefab, transform.position, transform.rotation);
    }

}
