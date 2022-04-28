using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class TopDownMovement2D : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rb2D.velocity = new Vector2(x * speed,y * speed);

    }
}
