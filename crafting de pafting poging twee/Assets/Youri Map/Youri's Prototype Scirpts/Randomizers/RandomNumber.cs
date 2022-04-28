using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomNumber : MonoBehaviour
{
    [SerializeField] private float Min;
    [SerializeField] private float Max;

    [SerializeField] private UnityEvent<float> SendValue;

    private int DecimalsCount;

    private void Start()
    {
        DecimalsCount = CountDigitsAfterDecimal(Min);
        if(DecimalsCount < CountDigitsAfterDecimal(Max))
        {
            DecimalsCount = CountDigitsAfterDecimal(Max);
        }
    }

    public void RandomValue()
    {
        SendValue.Invoke(Mathf.Round(Random.Range(Min * Mathf.Pow(10 , DecimalsCount), Max * Mathf.Pow(10, DecimalsCount))) / Mathf.Pow(10, DecimalsCount));
    }

    int CountDigitsAfterDecimal(float value)
    {
        bool start = false;
        int count = 0;
        foreach (var s in value.ToString())
        {
            if (s == ',' || s == '.')
            {
                start = true;
            }
            else if (start)
            {
                count++;
            }
        }
        return count;
    }
}
