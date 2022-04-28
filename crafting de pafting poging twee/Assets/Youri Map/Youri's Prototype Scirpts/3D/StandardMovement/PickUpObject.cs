using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public KeyCode keyCode;
    public Transform hand;
    private bool isHolding;
    public LayerMask layer;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,3,layer))
        {
            GameObject HandObject = hit.transform.gameObject;
            if (Input.GetKeyDown(keyCode) && !isHolding)
            {
                isHolding = true;
                HandObject.transform.parent = hand;
                HandObject.GetComponent<Rigidbody>().isKinematic = true;
                isHolding = true;
            }
            else if (Input.GetKeyDown(keyCode))
            {
               if(HandObject.GetComponent<Rigidbody>() != null)
                {
                     HandObject.GetComponent<Rigidbody>().isKinematic = false;
                }
                hand.DetachChildren();
                isHolding = false;
            }
        }
    }
}
