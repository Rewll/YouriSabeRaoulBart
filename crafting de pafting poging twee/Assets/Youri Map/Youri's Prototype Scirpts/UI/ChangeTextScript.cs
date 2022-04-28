using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextScript : MonoBehaviour
{
    [TextArea]
    [SerializeField] private string[] texts;
    private Text text;
    private void Awake()
    {
        text = gameObject.GetComponent<Text>();
    }

    public void ChangeText(int TextNumber)
    {
        if (TextNumber < texts.Length)
        {
            text.text = texts[TextNumber];
        }
    }
}
