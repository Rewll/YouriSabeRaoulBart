using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] private PotionIngredient potionIngredientSO;
    [SerializeField] private GameObject player;
    public IngredientGenerator ING;
    private PlayerStatsSO playerStatSORef;

    [SerializeField]
    private bool hasBeenPickedUpByPlayer;
    [SerializeField]
    private bool wordtGegooid;

    Vector3 mousePos;
    public float MoveSpeed = 10;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerStatSORef = Resources.Load<PlayerStatsSO>("ScriptableObjects/PlayerStats");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            wordtGegooid = false;
            //Debug.Log("boe " + collision.name);
        }
        //else if (!collision.CompareTag("Tutorial"))
        //{
        //    wordtGegooid = false;
        //    Debug.Log("boe " + collision.name);
        //}

        if (collision.gameObject.CompareTag("Cauldron"))
        {
            var Script = collision.gameObject.GetComponent<Cauldron>();
            Script.AddIngredient(potionIngredientSO);
            player.GetComponent<PlayerMovement>().inHand1 = false;
            if (ING) 
            { 
            ING.ingredientenVanDezeFabriek.Remove(this.gameObject);
            ING.instantieerIngredient();
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            wordtGegooid = false;
            //Debug.Log("boe " + collision.name);
        }
        //else if (!collision.CompareTag("Tutorial"))
        //{
        //    wordtGegooid = false;
        //    Debug.Log("boe " + collision.name);
        //}
    }

    public void Update()
    {
        
        if (transform.parent)
        {
            hasBeenPickedUpByPlayer = true;
        }
        else
        {
            hasBeenPickedUpByPlayer = false;
        }

        if (hasBeenPickedUpByPlayer && Input.GetMouseButtonDown(playerStatSORef.throwButton))
        {
            transform.parent = null;
            wordtGegooid = true;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
        }

        if (wordtGegooid)
        {
            transform.position = Vector2.MoveTowards(transform.position, mousePos, MoveSpeed * Time.deltaTime);
        }

        if (transform.position == mousePos) 
        {
            wordtGegooid = false;
            //Debug.Log("boe");
        }
    }
}