using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEntrance : MonoBehaviour
{
    SpriteRenderer renderer;
    Color oriColor;
    Color color;
    LayerMask layer;
    LayerMask oriLayer;
    

    private void Start()
    {
        oriLayer = gameObject.layer;
        layer = LayerMask.GetMask("CloudPlayer");
        renderer = gameObject.GetComponent<SpriteRenderer>();
        oriColor = renderer.color;
        color = oriColor;
        color.a = 0.49f;
    }

    void Update()
    {
        Player();
    }

    void Player()
    {
        if (renderer.color == oriColor)
        {
            renderer.color = color;
            gameObject.layer = layer;
            Invoke("EffectOver", 10f);
        }
    }

    void EffectOver()
    {
        gameObject.layer = oriLayer;
        renderer.color = oriColor;
        Destroy(GetComponent<CloudEntrance>());
    }
}
