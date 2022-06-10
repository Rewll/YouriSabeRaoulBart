using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVipAbility : MonoBehaviour
{
    private GameManagerSO managerSO;
    private float effectLength;
    private GameObject shades;
    private void Awake()
    {
        shades = Instantiate(Resources.Load<GameObject>("Prefabs/EpicShades"),transform.GetChild(0)); 
        managerSO = Resources.Load<GameManagerSO>("ScriptableObjects/GameManagerSO");
        effectLength = managerSO.VipAbilityLength;
        if (!managerSO)
        {
            Debug.LogWarning("GameManager Not Found in PlayerShrinkAbility");
            this.enabled = false;
            return;
        }
    }

    void Update()
    {
        effectLength -= Time.deltaTime;
        if (effectLength <= 0)
        {
            Destroy(shades);
            Destroy(this);
        }
    }
    public void AddLengthTime()
    {
        effectLength += managerSO.VipAbilityLength;
    }
}
