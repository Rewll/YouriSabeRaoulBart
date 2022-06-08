using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnetAbility : MonoBehaviour
{
    private GameManagerSO managerSO;
    private float effectLength;
    private GameObject magnetPrefab;
    // Start is called before the first frame update
    private void Awake()
    {
        managerSO = Resources.Load<GameManagerSO>("ScriptableObjects/GameManagerSO");
        magnetPrefab = Instantiate(Resources.Load<GameObject>("Prefabs/MagnetAbilityPrefab"), transform);
        effectLength = managerSO.beeAbilityLength;
    }
    // Update is called once per frame
    void Update()
    {
        effectLength -= Time.deltaTime;
        if (effectLength <= 0)
        {
            Destroy(magnetPrefab);
            Destroy(this);
        }
    }
    public void AddLengthTime()
    {
        effectLength += managerSO.beeAbilityLength;
    }
}
