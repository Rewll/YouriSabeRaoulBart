using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeStartDEKSEL : MonoBehaviour
{
    SpriteRenderer SR;

    public void OnEnable()
    {
        SR = GetComponent<SpriteRenderer>();
        StartCoroutine(doFadeIn(255, 150));
    }

    IEnumerator doFadeIn(float aValue, float aTime)
    {
        float alpha = SR.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            SR.color = newColor;
            yield return null;
        }
    }
}