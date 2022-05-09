using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelerVuur : MonoBehaviour
{
    SpriteRenderer SR;
    [SerializeField]
    private bool spelerIsHeet;
    [SerializeField]
    private float heetTijd;

    public void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    public void SpelerIsHeet()
    {
        Debug.Log("30 graden, redelijk warm");
        heetTijd += 10;
        //StartCoroutine(heetWorden());
    }

    private void Update()
    {
        if (heetTijd > 0)
        {
            heetTijd -= Time.deltaTime;
        }
        if (heetTijd > 0 && !spelerIsHeet)
        {
            spelerIsHeet = true;
            GetComponent<SpriteRenderer>().color = Color.red;
            Debug.Log("test");
        }
        else if (heetTijd <= 0 )
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            spelerIsHeet = false;
        }
    }
}