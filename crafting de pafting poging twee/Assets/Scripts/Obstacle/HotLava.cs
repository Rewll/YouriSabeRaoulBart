using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotLava : MonoBehaviour
{
    public GameObject player;
    private SpelerVuur spelerVuur;
    
    // Start is called before the first frame update
    void Start()
    {
        spelerVuur = player.GetComponent<SpelerVuur>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!spelerVuur && collision.CompareTag("Player"))
        {
            collision.transform.position = new Vector2(0, 0);
        }
        else
        {
            return;
        }
    }
}
