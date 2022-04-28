using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YLayering2D : MonoBehaviour
{
    [SerializeField] private int accuratey = 1;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sortingOrder = Mathf.RoundToInt(-transform.position.y * accuratey);
    }
}
