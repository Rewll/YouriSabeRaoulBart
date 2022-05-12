using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrowGroundCollision : MonoBehaviour
{
    public Transform[] ingredientObjects;
    public Collider2D groundCollider;
    
    // Start is called before the first frame update
    void Start()
    {   
        groundCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetClosestObjects(ingredientObjects);
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
