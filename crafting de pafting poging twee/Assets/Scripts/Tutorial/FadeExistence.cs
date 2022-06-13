using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeExistence : MonoBehaviour
{
    CanvasGroup CG;
    [SerializeReference]
    private bool onStartIN;
    [SerializeReference]
    private bool onStartOUT;
    public float fadeLengthDivider = 1;

    public void Awake()
    {
        CG = GetComponent<CanvasGroup>();
        if (onStartIN)
        {
            StartCoroutine(doFadeIn());
            CG.alpha = 0;
        }
        if (onStartOUT)
        {
            StartCoroutine(doFadeOUT());
            return;
        }
        CG.alpha = 0;
    }

    public void FadeIN()
    {
        StartCoroutine(doFadeIn());
    }

    IEnumerator doFadeIn()
    {
        while (CG.alpha < 1 )
        {
            CG.alpha += Time.deltaTime / fadeLengthDivider;
            yield return null;
        }
        yield return null;
    }
    public void FadeOUT()
    {
        StartCoroutine(doFadeOUT());
    }
    IEnumerator doFadeOUT()
    {
        while (CG.alpha > 0)
        {
            CG.alpha -= Time.deltaTime / fadeLengthDivider;
            yield return null;
        }
        yield return null;
    }
}