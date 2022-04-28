using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : MonoBehaviour
{
    [Header("TimerSettings")]
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;

    [Header("MoveArea")]
    [SerializeField] private float xArea;
    [SerializeField] private float yArea;

    [Header("otherSettings")]
    [SerializeField] private float speed = 1;
    [SerializeField] private float choas;

    private Vector3 walkpoint;
    private Vector3 oldpos;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();   
    }

    private void Start()
    {
        StartCoroutine("Timer");
        walkpoint = new Vector3(Random.Range(xArea, -xArea), Random.Range(yArea, -yArea),0);
        oldpos = transform.position;

    }
    private void Update()
    {
        Vector3 moveTo = Vector3.MoveTowards(transform.position, walkpoint, speed * Time.deltaTime);
        transform.position = moveTo + new Vector3(Random.Range(-choas, choas), Random.Range(choas, -choas), 0);
        if(moveTo.x  < oldpos.x - choas && spriteRenderer.flipX != true)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveTo.x > oldpos.x + choas && spriteRenderer.flipX != false)
        {
            spriteRenderer.flipX = false;
        }
        oldpos = moveTo;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(Random.Range(minTime,maxTime));
        walkpoint = new Vector3(Random.Range(xArea, -xArea), Random.Range(yArea, -yArea), 0);
        StartCoroutine("Timer");
    }
}
