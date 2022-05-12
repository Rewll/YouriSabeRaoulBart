using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint;
    public void RespawnPlayer() 
    {
        transform.position = respawnPoint.position;
    }
}
