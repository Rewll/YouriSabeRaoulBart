using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPotionEffect : MonoBehaviour
{
    public GameObject potionEffect;
    public GameObject textObject;
    public GameObject angryMan;
    public GameObject angryManText;
    public GameObject houseLightsOff;
    public GameObject houseLightsOn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        potionEffect.SetActive(true);
        textObject.SetActive(false);
        angryMan.SetActive(false);
        angryManText.SetActive(false);
        houseLightsOff.SetActive(false);
        houseLightsOn.SetActive(true);
        Destroy(this.gameObject);
    }
}
