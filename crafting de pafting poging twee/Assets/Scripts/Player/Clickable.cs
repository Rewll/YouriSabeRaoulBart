using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public bool klikt;

    public void OnMouseDown()
    {
        //Debug.Log("Geklikt op: " + gameObject.name);
        klikt = true;
    }

    public void OnMouseUp()
    {
        //Debug.Log("losgelaten op: " + gameObject.name);
        klikt = false;
    }
}