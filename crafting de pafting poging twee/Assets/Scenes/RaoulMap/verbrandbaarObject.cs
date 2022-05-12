using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verbrandbaarObject : MonoBehaviour
{
    private GameObject inDeFikSprite;

    private void Awake()
    {
        inDeFikSprite = Resources.Load<GameObject>("Prefabs/inDeFikSprite");
    }

    public void Brand()
    {
        Debug.Log("Kijk uit! " + this.name + " staat in de fik!!!!!");
        StartCoroutine(aanHetFikken());
    }

    IEnumerator aanHetFikken()
    {
        GameObject vuurSprite = Instantiate(inDeFikSprite, new Vector2(transform.position.x, transform.position.y - (transform.position.y / 2)), Quaternion.identity);
        vuurSprite.transform.parent = gameObject.transform;
        yield return new WaitForSeconds(3);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}