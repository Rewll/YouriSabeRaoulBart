using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionStartRandomizer : MonoBehaviour
{
    private Vector3 startpos;
    [SerializeField] private float speed;
    private void Awake()
    {
        if (transform.position != Vector3.zero) 
        {
            Destroy(this);
            return;
        }

        float tempx = Random.Range(1.0f, 3.0f);
        if(Random.Range(0,2) == 0) 
        {
            tempx *= -1;
        }
        float tempy = Random.Range(1.0f, 3.0f);
        if (Random.Range(0, 2) == 0)
        {
            tempy *= -1;
        }
        startpos = new Vector2(tempx,tempy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, startpos,Time.deltaTime * speed);;
        if(transform.position == startpos) 
        {
            Destroy(this);
        }
    }
}
