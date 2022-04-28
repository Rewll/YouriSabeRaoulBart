using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CounterScript : MonoBehaviour
{
    [Header("CountingData")]
    [SerializeField] private float startAmount;
    [SerializeField] private float endAmount;

    [Header("CountingSystem")]
    [SerializeField] private float addAmount;
    [Tooltip("Fill in ==,<,>,<= or >=")] [SerializeField] private string usedEqualSign = "==";

    [Header("other setting")]
    [SerializeField] bool autoReset;

    [Header("CountingEvent")]
    [SerializeField] private UnityEvent CountingDone;


    public float currentAmount;

    private void Awake()
    {
        currentAmount = startAmount;
        if(endAmount == startAmount)
        {
            Debug.LogWarning("startAmount and endAmount are the same");
        }
    }
    public void Count()
    {
        currentAmount = currentAmount + addAmount;

        switch (usedEqualSign)
        {
            case "==": 
                if(currentAmount == endAmount)
                {
                    CountingDone.Invoke();
                    if (autoReset == true) 
                    {
                        currentAmount = startAmount;
                    }
                }
                break;
            case "<":
                if (currentAmount < endAmount)
                {
                    CountingDone.Invoke();
                    if (autoReset == true)
                    {
                        currentAmount = startAmount;
                    }
                }
                break;
            case ">":
                if (currentAmount > endAmount)
                {
                    CountingDone.Invoke();
                    if (autoReset == true)
                    {
                        currentAmount = startAmount;
                    }
                }
                break;
            case "<=":
                if (currentAmount <= endAmount)
                {
                    CountingDone.Invoke();
                    if (autoReset == true)
                    {
                        currentAmount = startAmount;
                    }
                }
                break;
            case ">=":
                if (currentAmount >= endAmount)
                {
                    CountingDone.Invoke();
                    if (autoReset == true)
                    {
                        currentAmount = startAmount;
                    }
                }
                break;
            default:
                break;
        }
    }

    public void ResetCount()
    {
        currentAmount = startAmount;
    }

    public void ChangeAddAmount(float newValue)
    {
        addAmount = newValue;
    }
}
