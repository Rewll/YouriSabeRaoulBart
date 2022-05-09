using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEntrance : MonoBehaviour
{
    GameManagerSO managerSO;
    BoxCollider2D collider;
    SpriteRenderer renderer;
    Color oriColor;
    Color color;
    public bool isPlayer;

    private void Awake()
    {
        managerSO = Resources.Load<GameManagerSO>("ScriptableObjects/GameManagerSO");
    }

    private void Start()
    {
        collider = gameObject.GetComponent<BoxCollider2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        oriColor = renderer.color;
        color = oriColor;
        color.a = 0.49f;
    }

    void Update()
    {
        if (isPlayer)
        {
            Player();
        } else
        {
            Object();
        }
    }

    void Player()
    {

        if (managerSO.cloudActive == true && renderer.color == oriColor)
        {
            renderer.color = color;
        }
        else if (managerSO.cloudActive == false && renderer.color == color)
        {
            renderer.color = oriColor;
        }

    }

    void Object()
    {
        if (managerSO.cloudActive == true && collider.enabled == true)
        {
            collider.enabled = false;
        }
        else if (managerSO.cloudActive == false && collider.enabled == false)
        {
            collider.enabled = true;
        }

    }
}
