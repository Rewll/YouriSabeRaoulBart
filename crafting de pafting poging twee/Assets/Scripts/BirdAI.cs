using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAI : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask = 11;
    [SerializeField] private float moveSpeed;
    private SpriteRenderer birdRenderer;
    private GameObject target;
    private bool foundTarget;
    private bool toggle;
    // Start is called before the first frame update
    void Awake()
    {
        target = GetClosestIngredient();
        if (!target) 
        {
            StartCoroutine("DestoryTheObject");
        }
        birdRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!target && !toggle) 
        {
            StartCoroutine("DestoryTheObject");
            toggle = true;
        }
        if (!target) 
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(transform.position.x, 10000), Time.deltaTime * moveSpeed * 5);
            return;
        }
        CorrectOrienation();
        if (!foundTarget) 
        {
            FindTarget();
            if(transform.position == target.transform.position + new Vector3(0, 1.7f)) 
            {
                target.transform.parent = transform;
                foundTarget = true;
            }
        }
        else 
        {
            transform.position = Vector2.MoveTowards(transform.position, Vector3.zero + new Vector3(0, 1.7f), Time.deltaTime * moveSpeed);
        }
    }

    private GameObject GetClosestIngredient()
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 10, layerMask);
        foreach (var item in hits)
        {
            float dist = Vector3.Distance(item.transform.position, transform.position);
            if (dist < minDist)
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

    private void CorrectOrienation() 
    {
        if (!target) 
        {
            return;
        }
        if(!foundTarget && (transform.position.x - target.transform.position.x) < 0 || foundTarget && (transform.position.x - 0) < 0) 
        {
            birdRenderer.flipX = true;
        }
        else 
        {
            birdRenderer.flipX = false;
        }
    }
    private void FindTarget() 
    {
        if (target) 
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position + new Vector3(0, 1.7f), Time.deltaTime * moveSpeed);
        }
        
    }

    IEnumerator DestoryTheObject() 
    {
        Debug.Log("Start");
        yield return new WaitForSeconds(5);
        Debug.Log("Done");
        Destroy(gameObject);
    }
    
}
