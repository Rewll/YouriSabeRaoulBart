using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeverAbility : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer SR;
    private GameManagerSO managerSO;
    private PlayerStatsSO playerStats;

    [SerializeField]
    private bool spelerIsBever;
    private float beverTijdToevoeger;
    [SerializeField]
    private float beverTijd;
    //Color beverkleur = new Color(192, 92, 4, 1);
    private GameObject beverToevoeging;

    public void Awake()
    {
        managerSO = Resources.Load<GameManagerSO>("ScriptableObjects/GameManagerSO");
        playerStats = Resources.Load<PlayerStatsSO>("ScriptableObjects/PlayerStats");
        beverTijdToevoeger = managerSO.BeverAbilityLength;
        player = GameObject.Find("Player");
        SR = GameObject.Find("Lichaam").GetComponent<SpriteRenderer>();
        spelerWordtBever();
    }

    private void Update()
    {
        beverTijd -= Time.deltaTime;
        if (beverTijd <= 0)
        {
            spelerNietMeerBever();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            bijt();
        }
    }

    void bijt()
    {

    }

    public void spelerWordtBever()
    {
        beverTijd += beverTijdToevoeger;
        //SR.color = beverkleur;
        playerStats.playerColor = new Color(192, 92, 4, 1);
        //Debug.Log(SR.color);
        beverToevoeging = Instantiate(Resources.Load<GameObject>("Prefabs/BeverToevoeging"), transform.GetChild(0));
    }

    private void spelerNietMeerBever()
    {
        playerStats.playerColor = Color.white;
        //Debug.Log(SR.color);
        Destroy(beverToevoeging);
        Destroy(GetComponent<PlayerBeverAbility>());
    }

    public void langerBever()
    {
        beverTijd += beverTijdToevoeger;
    }
}