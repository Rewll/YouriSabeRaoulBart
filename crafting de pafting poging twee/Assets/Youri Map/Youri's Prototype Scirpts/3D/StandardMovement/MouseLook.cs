using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float ofsetX;    
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;
    private float xRotation;

 
    void Start()
    {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90,90);
        transform.localRotation = Quaternion.Euler(xRotation + ofsetX, 0f, 0f + ofsetX);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void SetMouseSensitivity(int newValue)
    {
        mouseSensitivity = newValue;
    }
}
 