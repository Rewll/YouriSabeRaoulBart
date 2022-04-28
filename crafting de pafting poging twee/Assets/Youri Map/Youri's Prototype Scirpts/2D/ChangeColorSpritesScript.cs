using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorSpritesScript : MonoBehaviour
{
    [ContextMenuItem("ChangecolorTest", "TestChangeColor")]
    [SerializeField] private Color[] colors;
    private SpriteRenderer SpriteRenderer;
    private void Awake()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void ChangeColor(int colornumber)
    {
        if (colornumber < colors.Length)
        {
            SpriteRenderer.color = colors[colornumber];
        }
        else
        {
            Debug.LogWarning(colornumber.ToString() + "is longer than the amount of colors");
        }
    }

    public void TestChangeColor()
    {
        Color color = new Color(1, 0, 1, 1);
        SpriteRenderer.color = color;
    }
}
