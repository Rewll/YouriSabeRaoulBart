using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrowObjectCollision : MonoBehaviour
{
    public Collider2D objectCollider;
    PotionThrowObjectCollision objectCollisionScript;
    PotionThrowGroundCollision groundColliderScript;
    
    // Start is called before the first frame update
    void Start()
    {
        objectCollisionScript = GetComponent<PotionThrowObjectCollision>();
        groundColliderScript = GetComponent<PotionThrowGroundCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Object Collision");
        //Set night to true
        groundColliderScript.enabled = true;
        objectCollisionScript.enabled = false;
        objectCollider.enabled = false;
    }
}