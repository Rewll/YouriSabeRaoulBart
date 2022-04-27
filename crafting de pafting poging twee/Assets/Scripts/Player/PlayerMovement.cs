using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int movementSpeed = 5;
    [SerializeField] int rotationSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        // Horizontal Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * movementSpeed * Time.deltaTime);

        // Vertical Movement
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * verticalInput * movementSpeed * Time.deltaTime);

        // Rotation
        Vector2 rotateDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(rotateDirection.x, rotateDirection.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
