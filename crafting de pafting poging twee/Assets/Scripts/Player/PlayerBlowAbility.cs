using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlowAbility : MonoBehaviour
{
    private GameObject blowAbilityPrefab;
    public GameManagerSO managerSO;
    
    private bool isBlowing;
    private float blowTime;
    private KeyCode abilityKey;

    private void Awake()
    {
        blowAbilityPrefab = Instantiate(Resources.Load<GameObject>("Prefabs/BlowAbilityPrefab"),transform.GetChild(0));
        managerSO = Resources.Load<GameManagerSO>("ScriptableObjects/GameManagerSO");
        if (!managerSO) 
        {
            Debug.LogWarning("GameManager Not Found in PlayerBlowAbility");
            this.enabled = false;
            return;
        }
        abilityKey = managerSO.abilityKeyCode;
        blowTime = managerSO.blowAbilityBlowTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(abilityKey) && !isBlowing) 
        {
            isBlowing = true;
            blowAbilityPrefab.SetActive(true);
            StartCoroutine(Blowtime());
        }
    }

    IEnumerator Blowtime() 
    {
        yield return new WaitForSeconds(blowTime);
        isBlowing = false;
        blowAbilityPrefab.SetActive(false);
    }
}



