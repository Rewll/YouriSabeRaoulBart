using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeksLatrine : MonoBehaviour
{
    public IngredientenObject testingSERKS;
    SpriteRenderer SR;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.sprite = testingSERKS.sprite;
        gameObject.name = testingSERKS.name;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
