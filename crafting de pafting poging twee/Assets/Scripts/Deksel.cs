using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Deksel : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private UnityEvent StartCooking;
    [SerializeField] private UnityEvent EndCooking;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cauldron") && playerMovement.inHand1)
        {
            transform.parent = null; 
            playerMovement.inHand1 = false;
            transform.position = new Vector3(0, 0, 0);
            StartCooking.Invoke();
        }
    }

    public void EndOfBrew() 
    {
        EndCooking.Invoke();
    }
}
