using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShrinkAbility : MonoBehaviour
{
    public GameManagerSO managerSO;
    private GameObject player;
    private KeyCode abilityKey;
    private float effectLength;
    // Start is called before the first frame update
    void Start()
    {
        managerSO = Resources.Load<GameManagerSO>("ScriptableObjects/GameManagerSO");
        if (!managerSO)
        {
            Debug.LogWarning("GameManager Not Found in PlayerBlowAbility");
            this.enabled = false;
            return;
        }
        abilityKey = managerSO.abilityKeyCode;
        effectLength = managerSO.blowAbilityLength;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
