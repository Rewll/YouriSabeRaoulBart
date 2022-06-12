using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LokBounce : MonoBehaviour
{
    private GameObject bouncer;
    private void Awake()
    {
        bouncer = GetClosestBounce();
        if (bouncer) 
        {
            bouncer.GetComponent<BounceAI>().SetTarget(transform);
        }
    }

    private GameObject GetClosestBounce()
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 10);
        foreach (var item in hits)
        {
            float dist = Vector3.Distance(item.transform.position, transform.position);
            if (dist < minDist && item.GetComponent<BounceAI>())
            {
                tMin = item.transform;
                minDist = dist;
            }
        }
        if (!tMin)
        {
            return null;
        }
        return tMin.gameObject;
    }
}
