using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] int rotationSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        // Rotation_1
        Vector2 rotateDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(rotateDirection.x, rotateDirection.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        // Rotation_2
        //Vector3 rotateDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //rotateDirection.Normalize();
        //float zRotation = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
    }
}
