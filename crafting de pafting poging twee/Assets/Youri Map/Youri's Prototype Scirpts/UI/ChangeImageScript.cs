using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageScript : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    private Image imageRenderer;
    private void Awake()
    {
        imageRenderer = gameObject.GetComponent<Image>();
    }

    public void ChangeImage(int SpriteNumber)
    {
        if(SpriteNumber < sprites.Length)
        {
            imageRenderer.sprite = sprites[SpriteNumber];
        }
    }
}
