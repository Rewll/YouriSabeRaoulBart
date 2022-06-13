using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorialability : MonoBehaviour
{
    private bool alreadyDone = false;
    public void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !alreadyDone)
        {
            Instantiate(Resources.Load<GameObject>("Prefabs/SpelerECHT(nep)"), transform.position + new Vector3(-4, 0), Quaternion.identity);
            //Instantiate(Resources.Load<GameObject>("Prefabs/SpelerECHT(nep)"), GameObject.Find("SpelerECHTPOS").transform.position, Quaternion.identity);
            alreadyDone = true;
        }
    }
}