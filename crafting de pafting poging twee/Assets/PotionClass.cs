using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PotionClass : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent ThrowPotion;
    [HideInInspector]
    public UnityEvent DrinkPotion;

    public PlayerMovement playerMovementReference;

    private void Awake()
    {
        playerMovementReference = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (!playerMovementReference.inHand1)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0)) //throw
        {
            ThrowPotion.Invoke();
            ThrowPotion.RemoveAllListeners();
            DrinkPotion.RemoveAllListeners();
            //Destroy(gameObject);    
        }
        if (Input.GetMouseButtonDown(1)) //drink
        {
            DrinkPotion.Invoke();
            ThrowPotion.RemoveAllListeners();
            DrinkPotion.RemoveAllListeners();
            //Destroy(gameObject);
        }
        //help
    }
}
