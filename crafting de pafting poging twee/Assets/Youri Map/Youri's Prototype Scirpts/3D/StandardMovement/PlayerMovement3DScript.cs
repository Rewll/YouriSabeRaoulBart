using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement3DScript : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private float speed = 12f;
    private float gravity = -9.81f;
    [SerializeField] private float gravityscale = 0.5f;

    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        controller = this.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime * gravityscale;

        velocity.y = Mathf.Clamp(velocity.y, -4f, 4f);
        controller.Move(velocity * Time.deltaTime);
    }

    public void CheesyJump()
    {
        velocity.y = 0;
        gravity = -gravity;
        transform.position = transform.position + new Vector3(0, 0.01f, 0);
    }
}
