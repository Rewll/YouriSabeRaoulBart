using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShrinkAbility : MonoBehaviour
{
    private GameManagerSO managerSO;
    private PlayerStatsSO statsSO;
    private GameObject player;
    private KeyCode abilityKey;
    private float effectLength;
    private GameObject mouseCostume;
    // Start is called before the first frame update
    void Awake()
    {
        managerSO = Resources.Load<GameManagerSO>("ScriptableObjects/GameManagerSO");
        if (!managerSO)
        {
            Debug.LogWarning("GameManager Not Found in PlayerShrinkAbility");
            this.enabled = false;
            return;
        }
        abilityKey = managerSO.abilityKeyCode;
        effectLength = managerSO.shrinkAbilityLength;
        player = GameObject.Find("Player");
        mouseCostume = Instantiate(Resources.Load<GameObject>("Prefabs/MouseMode"),transform.GetChild(0));
        statsSO = Resources.Load<PlayerStatsSO>("ScriptableObjects/PlayerStats");
        if (!player) 
        {
            Debug.LogWarning("PlayerStatsSo Not Found in PlayerShrinkAbility");
            this.enabled = false;
            return;
        }
        statsSO.playerColor = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(abilityKey)) 
        {
            player.transform.localScale = new Vector3(0.3f, 0.3f, 1);
        }
        else 
        {
            player.transform.localScale = new Vector3(1,1, 1);
        }

        effectLength -= Time.deltaTime;
        if (effectLength <= 0)
        {
            player.transform.localScale = new Vector3(1, 1, 1);
            statsSO.playerColor = Color.white;
            Destroy(mouseCostume);
            Destroy(this);
        }
    }
    public void AddLengthTime()
    {
        effectLength += managerSO.shrinkAbilityLength;
    }
}
