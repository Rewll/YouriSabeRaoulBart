using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEntrance : MonoBehaviour
{
    SpriteRenderer renderer;
    public GameObject child1;
    public GameObject child2;
    Color oriColor;
    Color color;
    LayerMask layer;
    LayerMask oriLayer;
    bool playerDone;
    

    private void Start()
    {
        child1 = gameObject.transform.GetChild(0).gameObject;
        child2 = child1.transform.GetChild(0).gameObject;
        oriLayer = gameObject.layer;
        layer = 8;
        renderer = child2.GetComponent<SpriteRenderer>();
        oriColor = renderer.color;
        color = oriColor;
        color.a = 0.49f;
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
        renderer.color = color;
        playerDone = true;
        Invoke("EffectOver", 10f);
    }

    void EffectOver()
    {
        gameObject.layer = oriLayer;
        renderer.color = oriColor;
        Destroy(GetComponent<CloudEntrance>());
    }
}
