using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayer : MonoBehaviour
{

    public void ChangeTheLayer(int newLayer) 
    {
        gameObject.layer = newLayer;
    }
        
}
