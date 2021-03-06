using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Vector2 _Movement;
    public GameObject _Hand1;
    public Transform topLeftBorder;
    public Transform bottomRightBorder;
    //public GameObject pickUpObjectText;
    //public GameObject handsFullText;
    public GameObject roteerbaarheid;
    PlayerStatsSO playerStatSORef;

    int movementSpeed = 5;
    public bool inHand1 = false;

    [SerializeField]
    private bool oppakKnopCheck;

    //public CollisionChecker colliderW, colliderA, colliderS, colliderD;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        roteerbaarheid = transform.GetChild(0).gameObject;
        playerStatSORef = Resources.Load<PlayerStatsSO>("ScriptableObjects/PlayerStats");
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + (_Movement * movementSpeed * Time.deltaTime));
    }

    // Update is called once per frame
    void Update()
    {
        _Movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        mouseLookAtPlayer();
        oppakKnopCheck = Input.GetMouseButton(playerStatSORef.throwButton);

        BoundaryCheck();
        handCheck();
    }

    public void ingredientThrow()
    {

    }

    void handCheck()
    {
        if (_Hand1.transform.childCount == 1)
        {
            inHand1 = true;
        }
        else if (_Hand1.transform.childCount > 1)
        {
            //Debug.LogError("meerdere dingen in hand, DIT IS ILLEGAAL");
        }
        else
        {
            inHand1 = false;
        }
    }

    public void mouseLookAtPlayer()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        roteerbaarheid.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    public void BoundaryCheck()
    {
        //// Out of bounds = respawn on other side
        if (!bottomRightBorder || !topLeftBorder)
        { 
            return;
        }
        // Top-Left
        if (transform.position.x < topLeftBorder.position.x)
        {
            transform.position = new Vector2(bottomRightBorder.position.x, transform.position.y);
        }

        if (transform.position.y > topLeftBorder.position.y)
        {
            transform.position = new Vector2(transform.position.x, bottomRightBorder.position.y);
        }
        
        // Bottom-Right
        if (transform.position.x > bottomRightBorder.position.x)
        {
            transform.position = new Vector2(topLeftBorder.position.x, transform.position.y);
        }

        if (transform.position.y < bottomRightBorder.position.y)
        {
            transform.position = new Vector2(transform.position.x, topLeftBorder.position.y);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (inHand1 == false)
    //    {
    //        pickUpObjectText.SetActive(true);
    //    }
    //    else
    //    {
    //        return;
    //    }

    //    if(inHand1 == true)
    //    {
    //        handsFullText.SetActive(true);
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        if (oppakKnopCheck && inHand1 == false  &&((collision.CompareTag("Ingredient") || collision.CompareTag("Potion"))))
        {
            if (collision.GetComponent<Clickable>() != null && collision.GetComponent<Clickable>().klikt)
            {
                collision.transform.position = _Hand1.transform.position;
                collision.transform.rotation = _Hand1.transform.rotation;
                collision.transform.SetParent(_Hand1.transform);
                //inHand1 = true;
                //Debug.Log("Picks up" + collision.name);
            }
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    pickUpObjectText.SetActive(false);
    //    handsFullText.SetActive(false);
    //}

    // NOT USED
    void playerMovement()
    {
        ////Horizontal Movement
        //float horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector2.right * horizontalInput * movementSpeed * Time.deltaTime);

        ////Vertical Movement
        //float verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector2.up * verticalInput * movementSpeed * Time.deltaTime);

        //if (Input.GetKey(KeyCode.W) && colliderW.isTouching == false)   
        //{
        //    transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.A) && colliderA.isTouching == false)
        //{
        //    transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.S) && colliderS.isTouching == false)
        //{
        //    transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.D) && colliderD.isTouching == false)
        //{
        //    transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        //}
    }
}