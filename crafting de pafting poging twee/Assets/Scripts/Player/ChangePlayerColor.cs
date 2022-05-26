using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerColor : MonoBehaviour
{
    private PlayerStatsSO playerStats;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        playerStats = Resources.Load<PlayerStatsSO>("ScriptableObjects/PlayerStats");
        playerStats.playerColor = Color.white;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = playerStats.playerColor;
    }
}
