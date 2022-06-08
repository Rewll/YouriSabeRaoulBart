using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHomeAbility : MonoBehaviour
{
    private GameObject player;
    private GameObject teleportAwayParticle;
    private GameObject teleportBackinParticle;

    private GameManagerSO managerSO;

    void Awake()
    {
        player = GameObject.Find("Player");
        teleportAwayParticle = Resources.Load<GameObject>("Prefabs/TeleportAway");
        teleportBackinParticle = Resources.Load<GameObject>("Prefabs/TeleportBackIn");
        managerSO = Resources.Load<GameManagerSO>("ScriptableObjects/GameManagerSO");
        StartCoroutine(Drinking());
    }

    IEnumerator Drinking()
    {
        player.transform.GetChild(0).gameObject.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = false;
        Instantiate(teleportAwayParticle, player.transform);
        yield return new WaitForSeconds(managerSO.TeleportAbilityWaitLength);
        player.GetComponent<PlayerMovement>().enabled = true;
        player.transform.GetChild(0).gameObject.SetActive(true);
        player.GetComponent<Respawn>().RespawnPlayer();
        Instantiate(teleportBackinParticle, player.transform);
        Destroy(this);
    }
}
