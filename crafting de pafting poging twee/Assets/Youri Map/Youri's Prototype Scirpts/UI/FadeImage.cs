using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    private Image image;
    [SerializeField] private float fadeInTime;
    [SerializeField] private float fadeOutTime;
    private bool fadeIn;
    private bool fadeOut;
    private float alpha;

    [Space]
    [SerializeField] UnityEvent fadeInDone;
    [SerializeField] UnityEvent fadeOutDone;
    void Start()
    {
        image = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            if(alpha < 1)
            {
                Color color = image.color;
                color.a = alpha;
                image.color = color;
                alpha = alpha + (1 / fadeInTime * Time.deltaTime);
            }
            else
            {
                fadeIn = false;
                alpha = 1;
                fadeInDone.Invoke();
            }

        }
        else if (fadeOut)
        {
            if (alpha > 0)
            {
                Color color = image.color;
                color.a = alpha;
                image.color = color;
                alpha = alpha - (1 / fadeOutTime * Time.deltaTime);
            }
            else
            {
                fadeOut = false;
                alpha = 0;
                fadeOutDone.Invoke();
            }
        }
    }

    public void FadeIn()
    {
        fadeIn = true;   
        fadeOut = false;   
    }

    public void FadeOut()
    {
        fadeIn = false;
        fadeOut = true;
    }

    public void ChangeFadeInTime()
    {

    }

    public void ChangeFadeOutTime()
    {

    }

}
