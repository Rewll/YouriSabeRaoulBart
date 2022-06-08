using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PotionClass : MonoBehaviour
{
    private ISideEffect[] sideEffects;
    private IMainEffect[] mainEffects;
    private GameObject player;
    [SerializeField] private LayerMask collitionLayers;
    [SerializeField] private float collisionRange = 2;

    private PlayerMovement Playermovement;
    private PlayerStatsSO playerStatSORef;
    [HideInInspector] public GameObject geraakteGameObject;
    [HideInInspector] public bool wordtGegooid;
    private bool isGeland;
    private bool hasBeenPickedUpByPlayer;
    Vector3 mousePos;

    public float MoveSpeed = 10;

    private void Awake()
    {
        player = GameObject.Find("Player");
        Playermovement = player.GetComponent<PlayerMovement>();
        playerStatSORef = Resources.Load<PlayerStatsSO>("ScriptableObjects/PlayerStats");
    }

    private void Update()
    {
        if (!playerStatSORef)
        {
            Debug.LogError("playerStatSORef IS ER NIET HELP CHAOS WAAAAA");
            return;
        }
        if(transform.parent != null) 
        {
            hasBeenPickedUpByPlayer = true;
        }

        if (!hasBeenPickedUpByPlayer)
        {
            return;
        }

        if (Input.GetMouseButtonDown(playerStatSORef.throwButton) && !wordtGegooid) //throw
        {
            transform.parent = null;
            //Playermovement.inHand1 = false;
            wordtGegooid = true;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
        }

        if (Input.GetMouseButtonDown(playerStatSORef.drinkButton) && !wordtGegooid) //drink
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
            //Playermovement.inHand1
            //= false;
            Destroy(gameObject);
        }

        if (wordtGegooid && !isGeland)
        {
            //Debug.Log("seks");
            transform.position = Vector2.MoveTowards(transform.position, mousePos, MoveSpeed * Time.deltaTime);
        }

        if (transform.position == mousePos && !isGeland) //if geland
        {
            isGeland = true;
            geraakteGameObject = GetClosestObject();
            if (geraakteGameObject == null)
            {
                //Debug.Log("Soep");
                Destroy(gameObject);
                throwExecution();
                return;
            }
            throwExecution();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (wordtGegooid && IsInLayerMask(collision.gameObject,collitionLayers)) 
        {
            geraakteGameObject = collision.transform.gameObject;
            if(geraakteGameObject != null) 
            { 
                throwExecution();
            }
        }
    }

    private void throwExecution()
    {
        //Debug.Log("gooi functie POEP");
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

    private GameObject GetClosestObject()
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Collider2D[]hits = Physics2D.OverlapCircleAll(transform.position,collisionRange, collitionLayers);
        foreach (var item in hits)
        {
            float dist = Vector3.Distance(item.transform.position,transform.position);
            if (dist < minDist)
            { 
                tMin = item.transform;
                minDist = dist;            
            }
        }
        if (!tMin) 
        {
            return null;
        }
        return tMin.gameObject;

    }

    public bool IsInLayerMask(GameObject obj, LayerMask layerMask)
    {
        return ((layerMask.value & (1 << obj.layer)) > 0);
    }

}