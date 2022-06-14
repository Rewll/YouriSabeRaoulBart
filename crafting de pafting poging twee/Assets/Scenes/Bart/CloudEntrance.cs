using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEntrance : MonoBehaviour
{
    private PlayerStatsSO playerStats;
    public GameObject child1;
    public GameObject child2;
    LayerMask layer;
    LayerMask oriLayer;
    bool playerDone;

    private void Awake()
    {
        playerStats = Resources.Load<PlayerStatsSO>("ScriptableObjects/PlayerStats");
    }
    private void Start()
    {
        child1 = gameObject.transform.GetChild(0).gameObject;
        child2 = child1.transform.GetChild(0).gameObject;
        oriLayer = gameObject.layer;
        layer = 8;
        playerStats.playerColor.a = 0.49f;
    }

    void Update()
    {
        if (!playerDone)
        {
            Player();
        }
    }

    void Player()
    {
        Debug.Log("Player");
        gameObject.layer = layer;
        playerDone = true;
        Invoke("EffectOver", 10f);
    }

    void EffectOver()
    {
        gameObject.layer = oriLayer;
        playerStats.playerColor.a = 1;
        Destroy(GetComponent<CloudEntrance>());
    }
}
