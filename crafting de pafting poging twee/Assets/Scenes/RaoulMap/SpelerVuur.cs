using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelerVuur : MonoBehaviour
{
    SpriteRenderer SR;
    [SerializeField]
    private bool spelerIsHeet;
    private float heetTijdToevoeger = 10;
    [SerializeField]
    private float heetTijd;

    public void Awake()
    {
        SpelerIsHeet();
    }

    public void SpelerIsHeet()
    {
        Debug.Log("30 graden, redelijk warm");
        heetTijd += heetTijdToevoeger;
        SR = GetComponent<SpriteRenderer>();
        GetComponent<SpriteRenderer>().color = Color.red;
        //heet logica

    }

    public void spelerWordtLangerHeet()
    {
        heetTijd += heetTijdToevoeger;
    }

    private void Update()
    {
        heetTijd -= Time.deltaTime;
        if (heetTijd <= 0 )
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            //niet meer heet logica
            Destroy(GetComponent<SpelerVuur>());
        }
    }
}