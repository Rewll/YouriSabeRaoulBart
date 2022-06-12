using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BounceAI : MonoBehaviour
{
    private Vector3 startPos;
    private Transform targetTransform;
    private Animator hoi;
    private BoxCollider2D hoi2;

    [SerializeField] private float moveSpeed;


    private void Awake()
    {
        startPos = transform.position;
        hoi = gameObject.GetComponent<Animator>();
        hoi2 = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetTransform) 
        {
            if (transform.position == startPos)
            {
                if (!hoi.GetBool("StandingStill")) 
                {
                    hoi.SetBool("StandingStill", true);
                }
                hoi2.enabled = true;
            }
            else 
            {
                if (hoi.GetBool("Party"))
                {
                    hoi.SetBool("Party", false);
                }
                if (!hoi.GetCurrentAnimatorStateInfo(0).IsName("UnTransform") && !hoi.GetCurrentAnimatorStateInfo(0).IsName("Transform")) 
                {
                    transform.position = Vector2.MoveTowards(transform.position, startPos, Time.deltaTime * moveSpeed);
                }
            }
        }
        else 
        {
            hoi2.enabled = false;
            if (transform.position == targetTransform.position)
            {
                if (!hoi.GetBool("Party"))
                {
                    hoi.SetBool("Party", true);
                }
            }
            else 
            {
                if (hoi.GetBool("StandingStill"))
                {
                    hoi.SetBool("StandingStill", false);
                }
                transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, Time.deltaTime * moveSpeed);
            }
        }
    }

    public void SetTarget(Transform newTarget) 
    {
        targetTransform = newTarget;
    }
}
