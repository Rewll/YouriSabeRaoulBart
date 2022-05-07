using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryManTextTrigger : MonoBehaviour
{
    public GameObject angryManText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        angryManText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        angryManText.SetActive(false);
    }
}
