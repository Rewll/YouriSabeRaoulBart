using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] Transform playerTransform;
    public GameObject _Hand1;
    public GameObject pickUpObjectText;
    public GameObject handsFullText;
    public GameObject roteerbaarheid;
    public CollisionChecker colliderW, colliderA, colliderS, colliderD;
    public KeyCode _Key;
    
    [SerializeField] int movementSpeed = 5;
    [SerializeField] float xMinPosition, xMaxPosition, yMinPosition, yMaxPosition;
    public bool inHand1 = false;

    private void Awake()
    {
        roteerbaarheid = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        mouseLookAtPlayer();
        playerMovement();
    }

    void playerMovement()
    {
        // Horizontal Movement
        //float horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector2.right * horizontalInput * movementSpeed * Time.deltaTime);

        // Vertical Movement
        //float verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector2.up * verticalInput * movementSpeed * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.W) && colliderW.isTouching == false)
        {
            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) && colliderA.isTouching == false)
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) && colliderS.isTouching == false)
        {
            transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) && colliderD.isTouching == false)
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }

        // Out of bounds = respawn on other side
        // Y
        if (transform.position.y < yMinPosition)
        {
            transform.position = new Vector2(transform.position.x, yMaxPosition);
        } 
        else if (transform.position.y > yMaxPosition)
        {
            transform.position = new Vector2(transform.position.x, yMinPosition);
        }

        // X
        if (transform.position.x < xMinPosition)
        {
            transform.position = new Vector2(xMaxPosition, transform.position.y);
        }
        else if(transform.position.x > xMaxPosition)
        {
            transform.position = new Vector2(xMinPosition, transform.position.y);
        }
    }

    public void mouseLookAtPlayer()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        roteerbaarheid.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
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