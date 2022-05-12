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
        // When potion throwing mechanic is finished!
        //groundColliderScript.enabled = true;
        //objectCollisionScript.enabled = false;
        //objectCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GetClosestObjects(ingredientObjects);
    }

    public Transform GetClosestObjects(Transform[] objektz)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in objektz)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }
}