using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinFlipScript : MonoBehaviour
{
    [SerializeField] private UnityEvent Heads;
    [SerializeField] private UnityEvent Tails;
    [SerializeField] private UnityEvent<bool> Result;
    public void TossCoin()
    {
        int flip = Random.Range(0, 2);
        if(flip == 1)
        {
            Heads.Invoke();
        }
        else if(flip == 0)
        {
            Tails.Invoke();
        }
        else
        {
            Debug.Log("Landed on its side");
        }
    }

    public void TossCoinResult()
    {
        int flip = Random.Range(0, 2);
        if (flip == 1)
        {
            Result.Invoke(true);
        }
        else if (flip == 0)
        {
            Result.Invoke(false);
        }
        else
        {
            Debug.Log("Landed on its side");
        }
    }

}
