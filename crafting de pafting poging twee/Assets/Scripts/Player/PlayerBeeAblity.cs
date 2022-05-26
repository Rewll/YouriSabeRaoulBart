using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeeAblity : MonoBehaviour
{
    private GameManagerSO managerSO;
    private PlayerStatsSO playerStats;
    private float effectLength;
    private GameObject beePrefab; 

    private void Awake()
    {
        managerSO = Resources.Load<GameManagerSO>("ScriptableObjects/GameManagerSO");
        playerStats = Resources.Load<PlayerStatsSO>("ScriptableObjects/PlayerStats");
        beePrefab = Instantiate(Resources.Load<GameObject>("Prefabs/BeeAbilityPrefab"), transform.GetChild(0));
        effectLength = managerSO.beeAbilityLength;
        playerStats.playerColor = new Color(1, 0.8f, 0, 1);
    }

    void Update()
    {
        effectLength -= Time.deltaTime;
        if (effectLength <= 0)
        {
            playerStats.playerColor = Color.white;
            Destroy(beePrefab);
            Destroy(this);
        }
    }
    public void AddLengthTime()
    {
        effectLength += managerSO.beeAbilityLength;
    }
}
