using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PotionClass : MonoBehaviour
{
    private ISideEffect[] sideEffects;
    private IMainEffect[] mainEffects;
    private GameObject player;

    private PlayerMovement Playermovement;
    public GameObject geraakteGameObject;
    private bool wordtGegooid;
    private bool isGeland;
    private bool hasBeenPickedUpByPlayer;
    Vector3 mousePos;

    public float MoveSpeed = 10;

    private void Awake()
    {
        player = GameObject.Find("Player");
        Playermovement = player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(transform.parent != null) 
        {
            hasBeenPickedUpByPlayer = true;
        }

        if (!hasBeenPickedUpByPlayer)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && !wordtGegooid) //throw
        {
            transform.parent = null;
            Playermovement.inHand1 = false;
            wordtGegooid = true;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
        }

        if (Input.GetMouseButtonDown(1) && !wordtGegooid) //drink
        {
            //mainEffect
            mainEffects = GetComponents<IMainEffect>();
            foreach (var mainEffect in mainEffects)
            {
                mainEffect.DrinkEffect();
            }
            //sideEffects
            sideEffects = GetComponents<ISideEffect>();
            foreach (var sideEffect in sideEffects)
            {
                sideEffect.DrinkEffect();
            }
            Playermovement.inHand1 = false;
            Destroy(gameObject);
        }

        if (wordtGegooid && !isGeland)
        {
            Debug.Log("seks");
            transform.position = Vector2.MoveTowards(transform.position, mousePos, MoveSpeed * Time.deltaTime);
        }

        if (transform.position == mousePos && !isGeland) //if geland
        {
            isGeland = true;
            geraakteGameObject = GetClosestObject().gameObject;
            if (geraakteGameObject == null)
            {
                Destroy(gameObject);
                return;
            }
            throwExecution();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) //if iets geraakt terwijl reizen
    { 
        geraakteGameObject = collision.gameObject;
        throwExecution();
    }

    private void throwExecution()
    {
        Debug.Log("gooi functie POEP");
        mainEffects = GetComponents<IMainEffect>();

        foreach (var mainEffect in mainEffects)
        {
            mainEffect.ThrowEffect();
        }
        //sideEffects
        sideEffects = GetComponents<ISideEffect>();
        foreach (var sideEffect in sideEffects)
        {
            sideEffect.ThrowEffect();
        }
        //animatie
        Destroy(gameObject);
    }

    private Transform GetClosestObject()
    {   
        List<Transform> objects = new List<Transform>();
        RaycastHit2D drankjeCirkel = Physics2D.CircleCast(transform.position, 2, Vector2.zero);
        if (drankjeCirkel)
        {
            Debug.Log(drankjeCirkel.transform);
            return drankjeCirkel.transform;
        }
        return null;
    }
}