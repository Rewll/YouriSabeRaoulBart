using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class SimpelTopDownAI : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private float speed = 1;

    private Rigidbody2D rb2D;
    
    private void Awake()
    {
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 0f;
    }

    void Update()
    {
        Vector3 Velocity = (Target.transform.position - this.gameObject.transform.position) * speed;
        rb2D.velocity = Velocity;
    }

    public void changeTransform(Transform transform) 
    {
        Target = transform;
    }
}
