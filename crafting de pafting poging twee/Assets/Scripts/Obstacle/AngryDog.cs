using UnityEngine;

public class AngryDog : MonoBehaviour
{
    private Rigidbody2D dogRigidbody;
    public Transform playerTransform;
    public Transform respawnPoint;
    public Transform dogHouseTransform;

    public float movementSpeed;

    private void Start()
    {
        dogRigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        AttackPlayer();
    }

    void AttackPlayer()
    {
        Vector2 moveDirection = playerTransform.position - this.transform.position;
        moveDirection.Normalize();
        if (playerTransform.position != respawnPoint.position && Vector2.Distance(transform.position, playerTransform.position) <= 10f)
        {
            dogRigidbody.MovePosition((Vector2)transform.position + (moveDirection * movementSpeed * Time.deltaTime));
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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = respawnPoint.position;
        }
    }
}
