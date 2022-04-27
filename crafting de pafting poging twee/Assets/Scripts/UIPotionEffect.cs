using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPotionEffect : MonoBehaviour
{
    public GameObject potionEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        potionEffect.SetActive(true);
        Destroy(this.gameObject);
    }
}
