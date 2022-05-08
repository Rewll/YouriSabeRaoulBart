using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] Transform playerTransform;
    public GameObject _Hand1;
    public GameObject pickUpObjectText;
    public GameObject handsFullText;
    public KeyCode _Key;
    
    [SerializeField] int movementSpeed = 5;
    //[SerializeField] int rotationSpeed = 10;
    public bool inHand1 = false;

    // Update is called once per frame
    void Update()
    {
        // Horizontal Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * movementSpeed * Time.deltaTime);

        // Vertical Movement
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * verticalInput * movementSpeed * Time.deltaTime);

        // Rotation_1
        //Vector3 rotateDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //rotateDirection.Normalize();
        //float zRotation = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
        
        // Rotation_2
        //Vector2 rotateDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float angle = Mathf.Atan2(rotateDirection.x, rotateDirection.y) * Mathf.Rad2Deg;
        //Quaternion rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inHand1 == false)
        {
            pickUpObjectText.SetActive(true);
        }

        else
        {
            handsFullText.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(_Key))
        {
            if (inHand1 == false && (collision.CompareTag("Ingredient") || collision.CompareTag("Potion")))
            {
                collision.transform.position = _Hand1.transform.position;
                collision.transform.rotation = _Hand1.transform.rotation;
                collision.transform.SetParent(_Hand1.transform);
                inHand1 = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pickUpObjectText.SetActive(false);
        handsFullText.SetActive(false);
    }
}
