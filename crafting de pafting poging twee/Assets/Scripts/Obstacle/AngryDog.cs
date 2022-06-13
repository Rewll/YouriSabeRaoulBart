using UnityEngine;

public class AngryDog : MonoBehaviour
{
    private Rigidbody2D dogRigidbody;
    public GameObject playerGameObject;
    //public Transform playerTransform;
    public Transform respawnPoint;
    public Transform dogHouseTransform;
    public GameObject dogCasualFace;
    private CloudEntrance cloudEntrance;

    public float movementSpeed;

    private void Start()
    {
        dogRigidbody = this.GetComponent<Rigidbody2D>();
        cloudEntrance = playerGameObject.GetComponent<CloudEntrance>();
    }

    private void Update()
    {  
        if(playerGameObject.layer != 8)
        {
            AttackPlayer();
        }
        else
        {
            ReturnToDogHouse();
        }
    }

    void AttackPlayer()
    {
        Vector2 moveDirection = playerGameObject.transform.position - this.transform.position;
        moveDirection.Normalize();
        if (playerGameObject.transform.position != respawnPoint.position && Vector2.Distance(transform.position, playerGameObject.transform.position) <= 8f)
        {
            dogRigidbody.MovePosition((Vector2)transform.position + (moveDirection * movementSpeed * Time.deltaTime));
            dogCasualFace.SetActive(false);
        }
        else
        {
            ReturnToDogHouse();
        }
    }

    void ReturnToDogHouse()
    {   
        Vector2 moveDirection = dogHouseTransform.position - this.transform.position;
        moveDirection.Normalize();
        if (Vector2.Distance(transform.position, dogHouseTransform.position) > 2f)
        {
            dogRigidbody.MovePosition((Vector2)transform.position + (moveDirection * movementSpeed * Time.deltaTime));
            dogCasualFace.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && playerGameObject.layer != 8)
        {
            collision.transform.position = respawnPoint.position;
        }

        if (collision.CompareTag("Pointy"))
        {
            Destroy(collision.gameObject);
            ReturnToDogHouse();
        }
    }
}
