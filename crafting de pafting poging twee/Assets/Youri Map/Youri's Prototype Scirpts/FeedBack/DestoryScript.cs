using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryScript : MonoBehaviour
{
    public void DestoryThisObject()
    {
        Destroy(gameObject);
    }

    public void DestoryAfter(float sec)
    {
        Destroy(gameObject,sec);
    }
}
